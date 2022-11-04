using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ProjectLexiconWebApp.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        [Precision(18, 2)]
        public decimal Wallet { get; set; }        
        public string FullName { get { return FirstName + " " + LastName; } }

        //FK
        //public int UserId { get; set; }
        //Navigation
        public List<Order> Orders { get; set; } = new List<Order>(); 
    }
}
