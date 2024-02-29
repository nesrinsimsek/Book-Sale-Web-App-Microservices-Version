using BookSaleDomainCore.Bus;
using EmailDomain.Commands;
using EmailDomain.Models;
using EmailDomain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.Services.Concrete
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
