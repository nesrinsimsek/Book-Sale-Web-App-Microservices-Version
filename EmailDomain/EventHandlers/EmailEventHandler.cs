using BookSaleDomainCore.Bus;
using EmailDomain.Events;
using EmailDomain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.EventHandlers
{
    public class EmailEventHandler : IEventHandler<EmailSentEvent>
    {
        private readonly IEmailSender _emailSender;
        public EmailEventHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task Handle(EmailSentEvent @event)
        {
            await _emailSender.Send(@event.EmailAddress, @event.MailContent, @event.MailSubject);
        }
    }
}
