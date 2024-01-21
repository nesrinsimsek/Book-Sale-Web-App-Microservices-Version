﻿using BookSale.Sale.Business.Abstract;
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

            //Domain Bus
            //services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            //{
            //    var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            //    return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            //});

            ////Subscriptions
            //services.AddTransient<TransferEventHandler>();

            ////Domain Events
            //services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            ////Domain Banking Commands
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            ////Application Services
            //services.AddTransient<IAccountService, AccountService>();
            //services.AddTransient<ITransferService, TransferService>();

            ////Data
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();
            //services.AddTransient<BankingDbContext>();
            //services.AddTransient<TransferDbContext>();
        }
    }
}
