using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Models
{
    public class OrderViewModel
    {
        public Cart Cart { get; set; }
        public OrderCreateDto OrderCreateDto { get; set; }
    }
}
