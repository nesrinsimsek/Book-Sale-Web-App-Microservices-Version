using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface IOrderBookService
    {
        Task AddOrderBook(OrderBook orderBook);
        Task<List<OrderBook>> GetOrderBookList();
    }
}
