using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Controllers;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebAppTests.Controllers
{
    public class CategoriesControllerTests
    {



        private async Task<ApplicationDbContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var applicationContext = new ApplicationDbContext(options);
            applicationContext.Database.EnsureCreated();

            if (await applicationContext.Categories.CountAsync() <= 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    applicationContext.Categories.Add(new Category()
                    {
                        Id = i,
                        Name = "Nuts and seeds"

                    });
                    await applicationContext.SaveChangesAsync();
                }
            }
            return applicationContext;
        }


        [Fact]
        public async void Return_CategoryIndexView()
        {

            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);
            var result = categoryController.Index();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void Return_ListBrandsIsNotEmpty()
        {
            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);
            var result = categoryController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var categories = Assert.IsType<List<Category>>(viewResult.Model);
            Assert.NotEmpty(categories);
        }



        [Fact]
        public async void Test_ReturnCategoryCreateView()
        {
            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);
            var result = categoryController.Create();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void TestCreateCategory_ValidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);

            Category category = new Category
            {
                Name = "Drink",
            };
            var result = await categoryController.Create(category);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }


        [Fact]
        public async void Return_CategoryEditView()
        {
            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);
            var result = categoryController.Edit(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var brand = Assert.IsType<Category>(viewResult.Model);
        }


        [Fact]
        public async void TestEditCategory()
        {
            var dbContext = await GetApplicationContext();
            using var categoryController = new CategoryController(dbContext);

            Category category = new Category
            {
                Id = 1,
                Name = "Tea",
            };

            var result = await categoryController.Edit(category);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }


    }
}

