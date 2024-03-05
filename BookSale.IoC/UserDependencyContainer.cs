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

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IUserDal, UserDal>();

            services.AddTransient<IRequestHandler<EmailCommand, bool>, EmailCommandHandler>();
            services.AddTransient<IEmailService, EmailService>();

        }
    }
}
