using BookSale.Sale.DataAccess.Abstract.Repositories;
using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.DataAccess.Abstract.Dals
{
    public interface IBookDal : IEntityRepository<Book>
    {
    }
}
