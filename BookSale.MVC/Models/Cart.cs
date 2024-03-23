namespace BookSale.MVC.Models
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; }
        public decimal TotalPrice
        {
            get { return CartLines.Sum(c => c.Quantity * c.Book.Price); }
        }

        public Cart()
        {
            CartLines = new List<CartLine>();
        }
    }
}
