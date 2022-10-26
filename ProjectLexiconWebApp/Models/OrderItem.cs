using System;
using System.Reflection.Metadata.Ecma335;

namespace ProjectLexiconWebApp.Models
{
    public class OrderItem
    {

        public int Id { get; set; }
        public int OrderId {get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price 
        {
            get { return (Quantity * Product.Price);  }
        }


        public OrderItem()
        { 
        }

    }
}

