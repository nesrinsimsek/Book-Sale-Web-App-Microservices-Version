using EFRepository;
using OrderDataAccess.Abstract;
using OrderDataAccess.Context;
using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataAccess.Concrete
{
    public class OrderBookDal : EntityRepository<OrderBook, OrderDbContext>, IOrderBookDal
    {
    }
}
