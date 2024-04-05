using AuthenticationDomain.Commands;
using AuthenticationDomain.Events;
using BookSaleDomainCore.Bus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDomain.CommandHandlers
{
    public class EmailCommandHandler : IRequestHandler<EmailCommand, bool>
    {
        private readonly IEventBus _bus; // RabbitMQBus classı DI yapılıyor

        public EmailCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        // _mediator.Send metodu buraya getiriyor (RabbitMQBus classındaki)
        // IRequestHandler'ın Handle metodunu override ediyoruz
        public Task<bool> Handle(EmailCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMQ
            _bus.Publish(new EmailSentEvent(request.EmailAddress, request.MailContent, request.MailSubject));
            return Task.FromResult(true);
        }
    }
}
