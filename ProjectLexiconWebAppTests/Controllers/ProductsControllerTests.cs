using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Controllers;
using ProjectLexiconWebApp.Data;
//using ProjectLexiconWebApp.Migrations;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;

namespace ProjectLexiconWebAppTests.Controllers
{
    public class ProductsControllerTests
    {



        private async Task<ApplicationDbContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var applicationContext = new ApplicationDbContext(options);
            applicationContext.Database.EnsureCreated();

            if( await applicationContext.Products.CountAsync() <= 0)
            {
                for(int i = 0; i <= 5; i++)
                {
                    applicationContext.Products.Add(new Product()
                    {
                        Id = i,
                        Name = "Granola",
                        Description = "description",
                        UnitPrice = 85.50m,
                        DiscountedPrice = 0.00m,
                        Size = "750g",
                        Quantity = 20

                    });
                    await applicationContext.SaveChangesAsync();
                }
            }
            return applicationContext;
        }


        [Fact]
        public async void Return_ProductIndexView()
        {

            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);
            var result = productController.Index();
            Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public async void Return_ListProductsNotEmpty()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var products = Assert.IsType<ProductsViewModel>(viewResult.Model);
            Assert.NotEmpty(products.Products);
        }

        [Fact]
        public async void Test_ProductCreateView()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Create();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void TestCreateProduct_ValidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var product = new CreateProductViewModel
            {

                ProductName = "walnuts",
                Description = "description",
                Price = 45.50m,
                Discount = 0.00m,
                Picture = "none",
                Size = "150g",
                Quantity = 20,
                BrandId = 1,
                CategoryId = 1
            };

            var result = await productController.Create(product);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }



        [Fact]
        public async void TestEdit()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Edit(2);
            var viewResult = Assert.IsType<ViewResult>(result);
            var product = Assert.IsType<Product>(viewResult.Model);
        }


        [Fact]
        public async void TestEditProduct()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var product = new Product
            {
                Id = 1,
                Name = "walnuts",
                Description = "description",
                UnitPrice = 30.00m,
                DiscountedPrice = 0.00m,
                Picture = "none",
                Size = "100g",
                Quantity = 15,
                BrandId = 1,
                CategoryId = 1
            };

            var result = await productController.Edit(product);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }




        [Fact]
        public async void TestDeleteProduct()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Delete(2);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }




        }
}

