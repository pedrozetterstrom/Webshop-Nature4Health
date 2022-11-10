using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using static ProjectLexiconWebApp.ViewModels.UserRoleViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectLexiconWebApp.Controllers
{
    public class ShoppingHistoryController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        readonly UserManager<ApplicationUser> _userManager;

        public ShoppingHistoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }


        // GET:
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                /* ViewBag.ErrorMessage = $"Error!!! You don´t have Access to this page!";
                 return PartialView("_ErrorPage");*/
                return PartialView("_OrderDetails");
            }
            else
            {
                var user = await _userManager.FindByNameAsync(id);
                return View(user);
            }
        }



        public async Task<IActionResult> ShoppingHistory(string email)
        {
            if (email != null && _dbContext.Customers.Any(customer => customer.EMail == email))
            {
                Customer customer = _dbContext.Customers
                .Include(customer => customer.Orders)
                .ThenInclude(order => order.OrderItems)
                .ThenInclude(item => item.Product)
                .Where(customer => customer.EMail == email).First();

                return View(customer);
            }
            else
            {
                ViewBag.ErrorMessage = $"Sorry!!! It seems you don´t have orders!";
                return PartialView("_ErrorPage");
            }
        }


        public async Task<IActionResult> OrderDetails(int id)
        {

            Order order = _dbContext.Orders
                 .Include(order => order.Customer)
                 .Include(order => order.OrderItems)
                 .ThenInclude(item => item.Product)
                 .Where(order => order.Id == id).First();


            return View(order);
        }


        public async Task<IActionResult> EditUserProfile(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(ApplicationUser user)
        {

            ApplicationUser userToEdit = await _userManager.FindByEmailAsync(user.Email);
            Customer customerToEdit = await _dbContext.Customers.Where(customer => customer.EMail == user.Email).FirstAsync();

            if (ModelState.IsValid)
            {
                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
                userToEdit.Address = user.Address;
                userToEdit.ZipCode = user.ZipCode;
                userToEdit.City = user.City;
                userToEdit.Phone = user.Phone;

                await _userManager.UpdateAsync(userToEdit);

                if (customerToEdit != null)
                {
                    customerToEdit.FirstName = user.FirstName;
                    customerToEdit.LastName = user.LastName;
                    customerToEdit.Address = user.Address;
                    customerToEdit.ZipCode = user.ZipCode;
                    customerToEdit.City = user.City;
                    customerToEdit.Phone = user.Phone;

                    _dbContext.Customers.Update(customerToEdit);
                    await _dbContext.SaveChangesAsync();
                }

                return RedirectToAction("Index", new { id = userToEdit.Email });

            }
            return View(userToEdit);

        }


        [HttpPost]
        public async Task<IActionResult> GuestOrderDetails(Order customerOrder)
        {
            Order ordermodel = await _dbContext.Orders
                .Include(order => order.Customer)
                .Include(order => order.OrderItems)
                .ThenInclude(item => item.Product)
                .Where(order => order.Id == customerOrder.Id).FirstAsync();

            return PartialView("_OrderDetails", ordermodel);
        }



    }

}