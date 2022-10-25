namespace ProjectLexiconWebApp.Models
{
    public class Shipper
    {
        public int Id { get; set; } //EF Core handles Id when name conventions is respected
        public string Name { get; set; } = string.Empty;

        //Navigation - Relationship To Orders
        public List<Order> Orders { get; set; } = new List<Order>();

       
    }
}
