using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.ViewModels
{
    public class ReceiptLineOrder
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalUnitsPrice
        {
            get
            {
                return UnitPrice * Quantity;
            }
        }
    }
}
