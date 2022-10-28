using System;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.ViewModels
{
    public class OrdersViewModel
    {

        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        //public List<OrderItem> OrderItems { get; set; }


        public OrdersViewModel()
        {
        }


    }
}

