using EmailDomain.Services.Abstract;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailDomain.Services.Concrete
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Sender(string emailAddress, string mailContent, string mailSubject)
        {
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("kitapkosesi.com@gmail.com", "Kitap Köşesi");
            var subject = mailSubject;
            var to = new EmailAddress(emailAddress);
            var plainTextContent = mailContent;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, null);
            await client.SendEmailAsync(msg);
        }
    }
}
