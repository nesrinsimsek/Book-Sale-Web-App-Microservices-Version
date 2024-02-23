using EFRepository;
using OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}
