using BookSale.MVC.Models.Dtos;
using BookSale.Sale.Entities.CartModels;

namespace BookSale.MVC.Models
{
    public class OrderViewModel
    {
        public Cart Cart { get; set; }
        public OrderCreateDto OrderCreateDto { get; set; }
    }
}
