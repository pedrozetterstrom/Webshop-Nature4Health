﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectLexiconWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public IActionResult Details(int id)
        {
            ordersModel.Orders = _dbContext.Orders
                .Include(customer => customer.Customer)
                .Include(order => order.OrderItems)
                .ThenInclude(orderitem => orderitem.Product)
                .ToList();
            ordersModel.Order = ordersModel.Orders.FirstOrDefault(o => o.Id == id);

            return View(ordersModel.Order);
        }

        [HttpPost]
        public IActionResult Edit(int id, int quantity)
        {
            var orderitem = _dbContext.OrderItems.FirstOrDefault(o => o.Id == id);
            if (orderitem != null)
            {
                orderitem.Quantity = quantity;
                _dbContext.OrderItems.Update(orderitem);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Details", new { id = orderitem.OrderId });
        }

        public IActionResult ChangeStatus(int id)
        {
            ordersModel.Order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (ordersModel.Order.Status.Contains("pending"))
            {
                ordersModel.Order.Status = "sent";
                _dbContext.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            if (ordersModel.Order.Status.Contains("sent"))
            {
                ordersModel.Order.Status = "delivered";
                _dbContext.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            if (ordersModel.Order.Status.Contains("delivered"))
            {
                ordersModel.Order.Status = "pending";
                _dbContext.SaveChanges();
                return RedirectToAction("Details", new { id = id });
            }
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult DeleteOrderItem(int id)
        {
            var item = _dbContext.OrderItems.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _dbContext.OrderItems.Remove(item);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Details", new {id = item.OrderId});
        }
        public IActionResult DeleteOrder(int id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

