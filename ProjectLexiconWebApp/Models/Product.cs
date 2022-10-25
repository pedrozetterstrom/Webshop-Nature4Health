namespace ProjectLexiconWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string? Picture { get; set; }
        public int Quantity { get; set; }        
        public double ProductRate { get; set; }
        public bool InStock 
        {
            get 
            {
                return (Quantity > 0) ? true : false;
            } 
        }

        public Category Category { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
