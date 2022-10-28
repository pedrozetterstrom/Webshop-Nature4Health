using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.ViewModels
{
    public class ProductsViewModel
    {

        public CreateProductViewModel createProductVM { get; set; }
        public List<Product> Products { get; set; }
        //public List<SelectListItem> BrandsList { get; set; }
        public List<SelectListItem> CategoriesList { get; set; }

        public Product Product { get; set; }


    public ProductsViewModel()
        {
            Products = new List<Product>();
          //  BrandsList = new List<SelectListItem>();
            CategoriesList = new List<SelectListItem>();
        }
    }
}

