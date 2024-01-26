using BookSale.Sale.Business.Abstract;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Dals;
using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task AddOrder(Order order)
        {
            await _orderDal.Add(order);
        }
        public async Task UpdateOrder(Order order)
        {
            await _orderDal.Update(order);
        }

        public async Task DeleteOrder(int orderId)
        {
            await _orderDal.Delete(o => o.Id == orderId);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderDal.Get(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrderListByUser(int userId)
        {
            return await _orderDal.GetList(o => o.User_Id == userId);
        }

        public async Task<List<Order>> GetOrderList()
        {
            return await _orderDal.GetList();
        }
    }
}
