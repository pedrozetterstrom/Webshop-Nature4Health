using ProjectLexiconWebApp.Models;

namespace ProjectLexiconWebApp.ViewModels
{
    public class ReceiptViewModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Shipper Shipper { get; set; }
        public List<Shipper> Shippers { get; set; }

        //In decimal form
        public decimal Vat { get; set; } = 0.25M;

        public string VatInProcent 
        {
            get 
            {
                return (Vat * 100).ToString() + " %";
            } 
        }

        public decimal VatCost 
        {
            get 
            {
                return Sum * Vat;
            } 
        }

        public decimal Sum 
        { 
            get
            {
                decimal totalSum = 0.0M;
                totalSum = Order.TotalCost;
                //foreach (var item in Order.OrderItems) 
                //{
                //    totalSum += (item.Product.UnitPrice * item.Quantity);
                //}

                return totalSum; 
            }
        }

        public decimal NetPrice
        {
            get
            {
                return Sum * (1.0M - Vat);
            }
        }

    }
}
