﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Controllers;
using ProjectLexiconWebApp.Data;
//using ProjectLexiconWebApp.Migrations;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;



namespace ProjectLexiconWebAppTests.Controllers
{
    public class BrandsControllerTests
    {


        private async Task<ApplicationDbContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var applicationContext = new ApplicationDbContext(options);
            applicationContext.Database.EnsureCreated();

            if (await applicationContext.Brands.CountAsync() <= 0)
            {
                for (int i = 0; i <= 4; i++)
                {
                    applicationContext.Brands.Add(new Brand()
                    {
                        Id = i,
                        Name = "RawFood"
                     
                    });
                    await applicationContext.SaveChangesAsync();
                }
            }
            return applicationContext;
        }



        [Fact]
        public async void Return_BrandIndexView()
        {

            var dbContext = await GetApplicationContext();
            using var brandController = new BrandController(dbContext);

            var result = brandController.Index();
            Assert.IsType<ViewResult>(result);

        }



        [Fact]
        public async void Return_ListBrandsIsNotEmpty()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            var result = brandsController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var brands = Assert.IsType<List<Brand>>(viewResult.Model);
            Assert.NotEmpty(brands);
        }



        [Fact]
        public async void Test_BrandCreateView()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            var result = brandsController.Create();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void TestCreateBrand_ValidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            Brand brand = new Brand
            {
             
                Name = "New Brand",
               
            };

            var result = await brandsController.Create(brand);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);

        }

        [Fact]
        public async void TestCreateBrand_InvalidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);
            brandsController.ModelState.AddModelError("Name", "Brand name is required");
            Brand brand = new Brand
            {
                Name = String.Empty
            };

            var result = await brandsController.Create(brand);
            var viewResult = Assert.IsType<ViewResult>(result);
            var brandmodel = Assert.IsType<Brand>(viewResult.Model);

        }



        [Fact]
        public async void TestCreateBrand_BrandAlreadyInList_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);
            Brand brand = new Brand
            {
                Name = "RawFood"
            };

            var result = await brandsController.Create(brand);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);

        }

        [Fact]
        public async void Return_EditView()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            var result = brandsController.Edit(2);
            var viewResult = Assert.IsType<ViewResult>(result);
            var brand = Assert.IsType<Brand>(viewResult.Model);
        }


        [Fact]
        public async void TestEditBrand_ValidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            Brand brand = new Brand
            {
                Id = 1,
                Name = "New Green",
                
            };

            var result = await brandsController.Edit(brand);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }


        [Fact]
        public async void TestEditBrand_InvalidModelState_ReturnEditView()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);
            brandsController.ModelState.AddModelError("Name", "Brand name is required");
            Brand brand = new Brand
            {
                Id = 1,
                Name = string.Empty

            };

            var result = await brandsController.Edit(brand);
            var viewResult = Assert.IsType<ViewResult>(result);
            var brandmodel = Assert.IsType<Brand>(viewResult.Model);
        }


        [Fact]
        public async void TestEditBrand_BrandAlreadyInList_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);
            Brand brand = new Brand
            {
                Id = 1,
                Name = "RawFood"

            };

            var result = await brandsController.Edit(brand);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);
        }


        [Fact]
        public async void TestDeleteBrand_ValidID()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);

            var result = await brandsController.Delete(5);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }


        /* brand id is being used for identifying a prooduct in the database */
        [Fact]
        public async void TestDeleteBrand_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var brandsController = new BrandController(dbContext);
            var result = await brandsController.Delete(1);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);
        }



    }
}

