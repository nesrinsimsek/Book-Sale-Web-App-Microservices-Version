using BookSale.Sale.Business.Abstract;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class OrderBookManager : IOrderBookService
    {

        private readonly IOrderBookDal _orderBookDal;

        public OrderBookManager(IOrderBookDal orderBookDal)
        {
            _orderBookDal = orderBookDal;
        }
        public async Task AddOrderBook(OrderBook orderBook)
        {
            await _orderBookDal.Add(orderBook);
        }

        public async Task<List<OrderBook>> GetOrderBookList()
        {
            return await _orderBookDal.GetList();
        }
    }
}
