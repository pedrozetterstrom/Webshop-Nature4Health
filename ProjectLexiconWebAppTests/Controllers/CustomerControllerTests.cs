using System;
using System.Net;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Controllers;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebAppTests.Controllers
{
    public class CustomerControllerTests
    {


        private async Task<ApplicationDbContext> GetApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var applicationContext = new ApplicationDbContext(options);
            applicationContext.Database.EnsureCreated();

            if (await applicationContext.Customers.CountAsync() <= 0)
            {
                for (int i = 1; i <= 5; i++)
                {
                    applicationContext.Customers.Add(new Customer()
                    {
                        Id = i,
                        FirstName = "New Customer",
                        LastName = "O",
                        EMail = "customer@n4h.com",
                        Address = "Kundsgatan",
                        ZipCode = "000000",
                        City = "Göteborg",
                        Phone = "00467982165",
                        CreatedAt = DateTime.Today,
                        Wallet = 1000.00m

                    }) ;
                    await applicationContext.SaveChangesAsync();
                }
            }
            return applicationContext;
        }



        [Fact]
        public async void Return_CustomerIndexView()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            var result = customerController.Index();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void Return_ListCustomersIsNotEmpty()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);

            var result = customerController.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var customers = Assert.IsType<List<Customer>>(viewResult.Model);
            Assert.NotEmpty(customers);
        }


        [Fact]
        public async void Test_CustomerCreateView()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            var result = customerController.Create();
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async void TestCreateNewCustomer_ValidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);

            Customer customer = new Customer
            {
                FirstName = "Daniel",
                LastName = "O",
                EMail = "daniel@n4h.com",
                Address = "Boråsgatan",
                ZipCode = "000000",
                City = "    Borås",
                Phone = "00467982165",
                CreatedAt = DateTime.Today,
                Wallet = 1000.00m

            };
            var result = await customerController.Create(customer);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async void TestCreateNewCustomer_InvalidModelState()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            customerController.ModelState.AddModelError("Address", "Address is required");
            Customer customer = new Customer
            {
                FirstName = "Daniel",
                LastName = "O",
                EMail = "daniel@n4h.com",
               // Address = "Boråsgatan",
                ZipCode = "000000",
                City = "    Borås",
                Phone = "00467982165",
                CreatedAt = DateTime.Today,
                Wallet = 1000.00m

            };
            var result = await customerController.Create(customer);
            var viewResult = Assert.IsType<ViewResult>(result);
            var customermodel = Assert.IsType<Customer>(viewResult.Model);
        }


        [Fact]
        public async void TestCreateNewCustomer_CustomerAlreadyInList_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);

            Customer customer = new Customer()
            {
                FirstName = "Pedro",
                LastName = "Feitoza",
                EMail = "user@user.com",
                Address = "Kungsgatan 1",
                ZipCode = "00000",
                City = "Göteborg",
                Phone = "46780964",
                CreatedAt = DateTime.Today,
                Wallet = 1000.0m
            };
            var result = await customerController.Create(customer);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);

        }


        [Fact]
        public async void TestEditView_Return_EditView()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            var result = customerController.Edit(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var customer = Assert.IsType<Customer>(viewResult.Model);
        }


        [Fact]
        public async void TestEditCustomer_CustomerAlreadyInList_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);

            Customer customer = new Customer()
            {
                Id = 2,
                FirstName = "Pedro",
                LastName = "Feitoza",
                EMail = "user@user.com",
                Address = "Kungsgatan 1",
                ZipCode = "00000",
                City = "Göteborg",
                Phone = "46780964",
                CreatedAt = DateTime.Today,
                Wallet = 1000.0m
            };
            var result = await customerController.Edit(customer);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);

        }


        [Fact]
        public async void TestEditCustomer_ReturnViewIndex()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "My Customer",
                LastName = "O",
                EMail = "customer@n4h.com",
                Address = "Customergatan",
                ZipCode = "000000",
                City = "Göteborg",
                Phone = "00467982165",
                CreatedAt = DateTime.Today,
                Wallet = 1000.00m
            };

            var result = await customerController.Edit(customer);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }


        [Fact]
        public async void TestEditCustomer_InvalidModelState_ReturnEditView()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            customerController.ModelState.AddModelError("Address", "Address is required");
            Customer customer = new Customer
            {
                Id = 1,
                FirstName = "My Customer",
                LastName = "O",
                EMail = "customer@n4h.com",
                Address = string.Empty,
                ZipCode = "000000",
                City = "Göteborg",
                Phone = "00467982165",
                CreatedAt = DateTime.Today,
                Wallet = 1000.00m
            };
            var result = await customerController.Edit(customer);
            var viewResult = Assert.IsType<ViewResult>(result);
            var customermodel = Assert.IsType<Customer>(viewResult.Model);
        }



        [Fact]
        public async void TestDeleteCustomer_ValidID_ReturnIndexView()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            var result = await customerController.Delete(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Index", viewResult.ViewName);
        }


        [Fact]
        public async void TestDeleteCustomer_InvalidID_ReturnErrorPage()
        {
            var dbContext = await GetApplicationContext();
            using var customerController = new CustomerController(dbContext);
            var result = await customerController.Delete(0);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            Assert.Equal("_ErrorPage", viewResult.ViewName);
        }



    }
}

