using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Contexts;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Repositories;
using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.DataAccess.Concrete.EntityFramework.Dals
{
    public class EfBookDal : EfEntityRepositoryBase<Book, SaleDbContext>, IBookDal
    {
    }
}
