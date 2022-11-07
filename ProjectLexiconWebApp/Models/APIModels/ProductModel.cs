using System;
namespace ProjectLexiconWebApp.Models.APIModels
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string? Picture { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public double? ProductRate { get; set; }
        public string InStock { get; set; } = string.Empty;
        public string? BrandName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

    }
}

