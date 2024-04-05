using BookSaleDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaleDomainCore.Bus
{
    // EmailEventHandler extend ediyor
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
