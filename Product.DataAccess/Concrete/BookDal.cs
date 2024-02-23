using EFRepository;
using Product.DataAccess.Abstract;
using Product.DataAccess.Context;
using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.DataAccess.Concrete
{
    public class BookDal : EntityRepository<Book, ProductDbContext>, IBookDal
    {
    }
}
