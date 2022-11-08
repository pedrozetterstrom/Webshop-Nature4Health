using System;
using System.Reflection.Metadata.Ecma335;

namespace ProjectLexiconWebApp.Models
{
    public class OrderItem
    {

        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId {get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price
        {
            get
            {
                if (Product.DiscountedPrice > 0)
                {
                    return (Quantity * Product.DiscountedPrice);
                }
                else
                {
                    return (Quantity * Product.UnitPrice);
                }
            }
        }


        public OrderItem()
        { 
        }

    }
}

