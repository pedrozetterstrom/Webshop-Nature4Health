using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectLexiconWebApp.ViewModels
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public string? Picture { get; set; }        
        public string ProductName { get; set; } = string.Empty;                        
        public int Quantity { get; set; }        
        public decimal UnitPrice { get; set; }
        
        //Added Late
        public string Size { get; set; } = string.Empty;


    }
}
