namespace ProjectLexiconWebApp.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        List<Product> Products { get; set; } = new List<Product>();

    }
}
