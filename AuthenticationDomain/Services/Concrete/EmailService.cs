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

        private readonly IEventBus _bus; // DI yapılan class RabbitMQBus

        public EmailService(IEventBus bus)
        {
            _bus = bus;
        }

        // RabbitMQBus classındaki SendCommand metodunu çağırıyor
        // SendCommand, mediatR'ın default olan Send metodunu çağırıyor
        // Send metodu parametre tipini IRequest bekliyor
        // EmailCommand -> Command -> IRequest extend ediyor o yüzden direkt Email göndermek yerine EmailCommand gönderdim
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
