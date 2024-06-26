﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.Models
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }
        [Precision(18, 2)]
        public decimal DiscountedPrice { get; set; }
        public string? Picture { get; set; }
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double? ProductRate { get; set; }
        public bool InStock
        {
            get
            {
                return (Quantity > 0) ? true : false;
            }
        }


        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public Brand? Brand { get; set; } //Brand name is good to have in Products table
        public int? BrandId { get; set; }


    }
}
