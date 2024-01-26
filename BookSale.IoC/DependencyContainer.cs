using BookSale.Sale.Business.Abstract;
using BookSale.Sale.Business.Concrete;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Dals;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    public class DependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IBookService, BookManager>();
            services.AddTransient<IBookDal, EfBookDal>();

            services.AddTransient<ICategoryService, CategoryManager>();
            services.AddTransient<ICategoryDal, EfCategoryDal>();

            services.AddTransient<IUserService, UserManager>();
            services.AddTransient<IUserDal, EfUserDal>();

            services.AddTransient<IOrderService, OrderManager>();
            services.AddTransient<IOrderDal, EfOrderDal>();
            
            services.AddTransient<IOrderBookService, OrderBookManager>();
            services.AddTransient<IOrderBookDal, EfOrderBookDal>();

        }
    }
}
