using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Business.Abstract
{
    public interface ICategoryManager
    {
        Task<List<Category>> GetCategoryList();
    }
}
