using Product.DataAccess.Abstract.Repository;
using Product.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Abstract.Dal
{
    public interface IBookDal : IEntityRepository<Book>
    {
    }
}
