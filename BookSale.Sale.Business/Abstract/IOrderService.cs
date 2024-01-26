using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface IOrderService
    {
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrderListByUser(int userId);
        Task<List<Order>> GetOrderList();


    }
}
