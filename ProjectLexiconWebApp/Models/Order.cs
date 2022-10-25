using System.ComponentModel.DataAnnotations;

namespace ProjectLexiconWebApp.Models
{
    public class Order
    {
        //You need to annotate it if NOT using just Id
        [Key]
        public int Id { get; set; }
        public int TotalCost { get; set; } = 0;
        public DateTime OrderDate { get; set; }

        public string Status { get; set; }


        //Navigations - Relationships to Orders
        //public int CustomerId { get; set; }     //FK
        //public Customer Customer { get; set; }

        //Navigations - Relationships to Shippers
        //public int ShipperId { get; set; }      //FK
        //public Shipper Shipper { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
