using Microsoft.Extensions.DependencyInjection;
using Product.Business.Abstract;
using Product.Business.Concrete;
using Product.DataAccess.Abstract;
using Product.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    public class ProductDependencyContainer
    {

        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IBookManager, BookManager>();
            services.AddTransient<IBookDal, BookDal>();

            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<ICategoryDal, CategoryDal>();

            //services.AddTransient<IUserService, UserManager>();
            //services.AddTransient<IUserDal, EfUserDal>();

            //services.AddTransient<IOrderService, OrderManager>();
            //services.AddTransient<IOrderDal, EfOrderDal>();
            
            //services.AddTransient<IOrderBookService, OrderBookManager>();
            //services.AddTransient<IOrderBookDal, EfOrderBookDal>();

        }
    }
}
