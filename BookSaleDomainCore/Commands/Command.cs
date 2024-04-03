using BookSaleDomainCore.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSaleDomainCore.Commands
{
    // mediatR'ın Send metoduna IRequest tipinde parametre göndermek için kullanıyorum
    // EmailCommand classını extend ediyorum
    public abstract class Command : IRequest<bool>
    {
        public DateTime Timestamp { get; protected set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
