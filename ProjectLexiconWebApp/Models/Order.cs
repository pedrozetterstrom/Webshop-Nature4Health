using System.ComponentModel.DataAnnotations;

namespace ProjectLexiconWebApp.Models
{
    public class Order
    {
        //You need to annotate it if NOT using just Id
        [Key]
        public int Id { get; set; }
        public decimal TotalCost
        {
            get
            {
                decimal TotalCost = 0m;
                foreach (var i in OrderItems)
                {
                    TotalCost = TotalCost + i.Price;
                }
                if(ShipperId == 1) { TotalCost += 60; }
                else if(ShipperId == 2) { TotalCost += 25; }
                else if(ShipperId == 3) { TotalCost += 40; }
                return TotalCost;
            }
        }
        public DateTime OrderDate { get; set; }

        public string Status { get; set; } = string.Empty;


        //Navigations - Relationships to Orders
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }     //FK


        //Navigations - Relationships to Shippers
        public Shipper? Shipper { get; set; }
        public int? ShipperId { get; set; } 

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
