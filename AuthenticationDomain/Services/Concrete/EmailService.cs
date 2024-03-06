using AuthenticationDomain.Commands;
using AuthenticationEntity.Models;
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
                    email.MailContent,
                    email.MailSubject
                );

            _bus.SendCommand(emailCommand);
        }

    }
}
