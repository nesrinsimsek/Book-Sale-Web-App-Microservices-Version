using BookSaleDomainCore.Bus;
using EmailDomain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.EventHandlers
{
    public class EmailEventHandler : IEventHandler<EmailSentEvent>
    {
        public Task Handle(EmailSentEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
