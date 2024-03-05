using AuthenticationEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationDomain.Services.Abstract
{
    public interface IEmailService
    {
        void SendMail(Email email);
    }
}
