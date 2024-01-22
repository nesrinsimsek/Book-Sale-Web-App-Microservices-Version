using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoryList();
    }
}
