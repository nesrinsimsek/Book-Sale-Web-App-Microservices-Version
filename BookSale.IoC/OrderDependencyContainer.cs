using Microsoft.Extensions.DependencyInjection;
using OrderBusiness.Abstract;
using OrderBusiness.Concrete;
using OrderDataAccess.Abstract;
using OrderDataAccess.Concrete;
using Product.Business.Abstract;
using Product.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    public class OrderDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //services.AddTransient<IBookManager, BookManager>();
            //services.AddTransient<IBookDal, BookDal>();

            //services.AddTransient<ICategoryManager, CategoryManager>();
            //services.AddTransient<ICategoryDal, CategoryDal>();

            //services.AddTransient<IUserService, UserManager>();
            //services.AddTransient<IUserDal, EfUserDal>();

            services.AddTransient<IOrderManager, OrderManager>();
            services.AddTransient<IOrderDal, OrderDal>();

            //services.AddTransient<IOrderBookService, OrderBookManager>();
            //services.AddTransient<IOrderBookDal, EfOrderBookDal>();

        }
    }
}
