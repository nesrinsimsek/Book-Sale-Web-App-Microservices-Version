using BookSaleDomainCore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.Events
{
    public class EmailSentEvent : Event
    {
        public string EmailAddress { get; set; }
        public string MailContent { get; set; }
        public string MailSubject { get; set; }

        public EmailSentEvent(string emailAddress, string mailContent, string mailSubject)
        {
            EmailAddress = emailAddress;
            MailContent = mailContent;
            MailSubject = mailSubject;
        }
    }
}
