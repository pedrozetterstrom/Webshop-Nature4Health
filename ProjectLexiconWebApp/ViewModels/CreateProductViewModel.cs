using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.ViewModels
{
    public class CreateProductViewModel
    {

        [Required(ErrorMessage = "Product name is required!")]
        [Display(Name = "Product Name:")]
        public string ProductName { get; set; } = string.Empty;


        [Display(Name = "Product Description:")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Product price is required")]
        [Display(Name = "Product price per unit:")]
        public decimal Price { get; set; }

        [Display(Name = "Discount:")]
        public decimal Discount { get; set; } 

        [Display(Name = "Product image:")]
        public string? Picture { get; set; }

        [Required(ErrorMessage = "Product size is required")]
        [Display(Name = "Product size:")]
        public string Size { get; set; } = string.Empty;

        [Required(ErrorMessage = "Product quantity is required")]
        [Display(Name = "Quantity:")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Product rate is required")]
        [Display(Name = "Product Rate:")]
        public double? ProductRate { get; set; }

        [Required(ErrorMessage = "Brand name is required")]
        [Display(Name = "Brand Name:")]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [Display(Name = "Category Name:")]
        public int CategoryId { get; set; }




        public CreateProductViewModel()
        {
        }


     
    }
}

