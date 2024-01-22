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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<List<Order>> GetOrderList()
        {
            throw new NotImplementedException();
        }
        public async Task Add(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Order order)
        {
            throw new NotImplementedException();
        }



        public async Task Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
