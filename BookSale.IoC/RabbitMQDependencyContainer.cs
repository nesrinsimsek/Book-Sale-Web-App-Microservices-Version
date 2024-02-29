using BookSaleBus;
using BookSaleDomainCore.Bus;
using EmailDomain.CommandHandlers;
using EmailDomain.Commands;
using EmailDomain.Services.Abstract;
using EmailDomain.Services.Concrete;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookSale.IoC
{
    public class RabbitMQDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });

            services.AddTransient<IRequestHandler<EmailCommand, bool>, EmailCommandHandler>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
