using BookSaleDomainCore.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDomain.Commands
{
    public class EmailCommand : Command
    {
        public string EmailAddress { get; set; }
        public string MailContent { get; set; }

        public EmailCommand(string emailAddress, string mailContent)
        {
            EmailAddress = emailAddress;
            MailContent = mailContent;
        }
    }
}
