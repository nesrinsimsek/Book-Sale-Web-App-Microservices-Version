using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Models
{
    public class CartLine 
    {
        public BookDto Book { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice
        {
            get { return Quantity * Book.Price; }
        }

    }
}
