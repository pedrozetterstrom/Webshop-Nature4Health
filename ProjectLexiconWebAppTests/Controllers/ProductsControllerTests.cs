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
        public async void TestCreateProduct_InvalidModelState_ReturnCreateView()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);
            productController.ModelState.AddModelError("ProductName", "Product name is required");
            var product = new CreateProductViewModel
            {
               // ProductName = "walnuts",
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
            var viewResult = Assert.IsType<ViewResult>(result);
            var createProductViewModel= Assert.IsType<CreateProductViewModel>(viewResult.Model);
        }


        [Fact]
        public async void TestCreateProduct_ProducAlreadyInList_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);
            
            var product = new CreateProductViewModel
            {
                ProductName = "Honey",
                Description = "",
                Price = 34.5m,
                Discount = 0.0m,
                Size = "100g",
                Quantity = 20,
                CategoryId = 4,
                BrandId = 1
      
            };
            var result = await productController.Create(product);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);
        }



        [Fact]
        public async void TestEditView()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Edit(2);
            var viewResult = Assert.IsType<ViewResult>(result);
            var product = Assert.IsType<Product>(viewResult.Model);
        }


        [Fact]
        public async void TestEditProduct_ValidModelState()
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
        public async void TestEditProduct_InvalidModelState_ReturnEditView()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);
            productController.ModelState.AddModelError("Name", "Product name is required");
            Product product = new Product
            {
                Id = 1,
              //  Name = "walnuts",
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
            var viewResult = Assert.IsType<ViewResult>(result);
            var productmodel = Assert.IsType<Product>(viewResult.Model);
        }


        [Fact]
        public async void TestDeleteProduct_ValidID()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);

            var result = productController.Delete(2);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async void TestDeleteProduct_InvalidID_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var productController = new ProductController(dbContext);
            var result = productController.Delete(0);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);
        }




    }
}

