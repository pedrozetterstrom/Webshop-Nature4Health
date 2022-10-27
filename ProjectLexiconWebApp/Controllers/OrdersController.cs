using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectLexiconWebApp.Controllers
{
    public class OrdersController : Controller
    {

        private readonly ApplicationDbContext _dbContext;
        OrdersViewModel ordersModel = new OrdersViewModel();


        public OrdersController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET:
        public IActionResult Index()
        {

            ordersModel.Orders = _dbContext.Orders
                .Include(customer => customer.Customer)
                .Include(order => order.OrderItems)
                .ThenInclude(orderitem => orderitem.Product)
                .ToList();

            return View(ordersModel);
        }
    }
}

