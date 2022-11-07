using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectLexiconWebApp.Models
{
    public class Customer 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required!")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required!")]
        [Display(Name = "Email:")]
        public string EMail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required!")]
        [Display(Name = "Address:")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "ZipCode is required!")]
        [Display(Name = "ZipCode:")]
        public string ZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required!")]
        [Display(Name = "City Name:")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required!")]
        [Display(Name = "Phone:")]
        public string Phone { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        //FREE fake money - Daniel
        [Required(ErrorMessage = "Payment is required!")]
        [Display(Name = "Wallet:")]
        public decimal Wallet { get; set; }
        
        public string FullName { get { return FirstName + " " + LastName; } }

        //FK
        public string? UserId { get; set; }
        //Navigation
        public List<Order> Orders { get; set; } = new List<Order>(); 
    }
}
