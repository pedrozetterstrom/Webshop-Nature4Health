namespace ProjectLexiconWebApp.Models
{
	public class ShoppingCart
	{
		public int Id { get; set; }
		public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public int CustomerId { get; set; }	//FK

		public void AddToCart(Product product) 
		{
			ShoppingCartItem itemInCart = new ShoppingCartItem{ Id = product.Id, ShoppingCartId="DSFFSDSDF", Amount=1 };
		}
	}
}
