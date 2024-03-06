using BookSaleDomainCore.Bus;
using EmailDomain.EventHandlers;
using EmailDomain.Events;
using EmailDomain.Services.Abstract;
using EmailDomain.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.IoC
{
    public class EmailDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<EmailEventHandler>();
            services.AddTransient<IEventHandler<EmailSentEvent>, EmailEventHandler>();
            services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
