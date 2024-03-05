using AuthenticationBusiness.Abstract;
using AuthenticationBusiness.Concrete;
using AuthenticationDataAccess.Abstract;
using AuthenticationDataAccess.Concrete;
using AuthenticationDomain.CommandHandlers;
using AuthenticationDomain.Commands;
using AuthenticationDomain.Services.Abstract;
using AuthenticationDomain.Services.Concrete;
using BookSaleBus;
using BookSaleDomainCore.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Product.Business.Abstract;
using Product.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    public class UserDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //services.AddTransient<IBookManager, BookManager>();
            //services.AddTransient<IBookDal, BookDal>();

            //services.AddTransient<ICategoryManager, CategoryManager>();
            //services.AddTransient<ICategoryDal, CategoryDal>();

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserDal, UserDal>();

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<IRequestHandler<EmailCommand, bool>, EmailCommandHandler>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IMediator, Mediator>();

            //services.AddTransient<IOrderService, OrderManager>();
            //services.AddTransient<IOrderDal, EfOrderDal>();

            //services.AddTransient<IOrderBookService, OrderBookManager>();
            //services.AddTransient<IOrderBookDal, EfOrderBookDal>();

        }
    }
}
