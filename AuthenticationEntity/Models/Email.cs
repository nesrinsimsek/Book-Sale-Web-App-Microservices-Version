using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationEntity.Models
{
    public class Email
    {
        public string EmailAddress { get; set; }
        public string MailContent { get; set; }

        public Email(string emailAddress, string mailContent)
        {
            EmailAddress = emailAddress;
            MailContent = mailContent;
        }
    }
}
