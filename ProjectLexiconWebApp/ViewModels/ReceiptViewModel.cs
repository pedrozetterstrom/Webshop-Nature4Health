namespace ProjectLexiconWebApp.ViewModels
{
    public class ReceiptViewModel
    {
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }

        public string FullName { get; set; }

        public string  Address { get; set; }

        public string ZipCode { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ReceiptLineOrder> ListItems { get; set; } = new List<ReceiptLineOrder>();

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

                foreach (var item in ListItems) 
                {
                    totalSum += (item.UnitPrice * item.Quantity);
                }

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
