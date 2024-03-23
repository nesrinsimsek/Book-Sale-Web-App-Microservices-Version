using BookSale.MVC.Models.Dtos;
using OrderEntity.CartModels.Concrete;

namespace BookSale.MVC.Models
{
    public class OrderViewModel
    {
        public Cart Cart { get; set; }
        public OrderCreateDto OrderCreateDto { get; set; }
    }
}
