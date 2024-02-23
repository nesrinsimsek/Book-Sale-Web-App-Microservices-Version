using Product.DataAccess.Abstract.Dal;
using Product.DataAccess.Concrete.Context;
using Product.DataAccess.Concrete.Repository;
using Product.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Concrete.Dal
{
    public class BookDal : EntityRepository<Book, ProductDbContext>, IBookDal
    {
    }
}
