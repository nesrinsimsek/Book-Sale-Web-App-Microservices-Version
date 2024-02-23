using Product.Business.Abstract;
using Product.DataAccess.Abstract;
using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Business.Concrete
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public async Task<List<Category>> GetCategoryList()
        {
            return await _categoryDal.GetList();
        }
    }
}
