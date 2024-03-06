using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.Services.Abstract
{
    public interface IEmailSender
    {
        Task Sender(string emailAddress, string mailContent, string mailSubject);
    }
}
