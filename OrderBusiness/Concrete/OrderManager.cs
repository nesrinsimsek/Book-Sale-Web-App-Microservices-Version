using OrderBusiness.Abstract;
using OrderDataAccess.Abstract;
using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderBusiness.Concrete
{
    public class OrderManager : IOrderManager
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
        public async Task<List<Order>> GetOrderList()
        {
            return await _orderDal.GetList();
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _orderDal.Get(o => o.Id == id);
        }
    }
}
