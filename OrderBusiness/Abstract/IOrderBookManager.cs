using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusiness.Abstract
{
    public interface IOrderBookManager
    {
        Task AddOrderBook(OrderBook orderBook);
        Task<List<OrderBook>> GetOrderBookList();
    }
}
