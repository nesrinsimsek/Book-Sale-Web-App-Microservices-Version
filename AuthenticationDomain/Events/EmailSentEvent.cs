using BookSaleDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDomain.Events
{
    public class EmailSentEvent : Event
    {
        public string EmailAddress { get; set; }
        public string MailContent { get; set; }

        public EmailSentEvent(string emailAddress, string mailContent)
        {
            EmailAddress = emailAddress;
            MailContent = mailContent;
        }
    }
}
