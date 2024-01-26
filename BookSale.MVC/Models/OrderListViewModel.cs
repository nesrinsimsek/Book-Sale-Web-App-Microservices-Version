using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Models
{
    public class OrderListViewModel
    {
        public OrderDto Order { get; set; }
        public List<BookDto> BookList = new List<BookDto>();
        public UserDto User { get; set; }
        public OrderBookDto OrderBook { get; set; }
    }
}
