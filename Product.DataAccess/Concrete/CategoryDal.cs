using EFRepository;
using Product.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.DataAccess.Abstract;
using Product.Entity.Entities;

namespace Product.DataAccess.Concrete
{
    public class CategoryDal : EntityRepository<Category, ProductDbContext>, ICategoryDal
    {
    }
}
