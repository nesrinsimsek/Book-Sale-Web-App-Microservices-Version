using BookSaleBus;
using BookSaleDomainCore.Bus;
using Microsoft.Extensions.DependencyInjection;
using OrderBusiness.Abstract;
using OrderDataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    internal class RabbitMQBusDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IEventBus, RabbitMQBus>();

        }
    }
}
