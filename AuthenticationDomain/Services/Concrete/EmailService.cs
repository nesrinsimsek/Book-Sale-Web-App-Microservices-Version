using AuthenticationDomain.Commands;
using AuthenticationDomain.Models;
using AuthenticationDomain.Services.Abstract;
using BookSaleDomainCore.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDomain.Services.Concrete
{
    public class EmailService : IEmailService
    {

        private readonly IEventBus _bus;

        public EmailService(IEventBus bus)
        {

            _bus = bus;
        }


        public void SendMail(Email email)
        {
            var emailCommand = new EmailCommand(
                    email.EmailAddress,
                    email.MailContent
                );

            _bus.SendCommand(emailCommand);
        }

    }
}
