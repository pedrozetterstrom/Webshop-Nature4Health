using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand name is required!")]
        [Display(Name = "Brand Name:")]
        public string Name { get; set; } = String.Empty;

        List<Product> Products { get; set; } = new List<Product>();

    }
}
