using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required!")]
        [Display(Name = "Category name:")]
        public string Name { get; set; } = String.Empty;

        List<Product> Products { get; set; } = new List<Product>();
    }
}
