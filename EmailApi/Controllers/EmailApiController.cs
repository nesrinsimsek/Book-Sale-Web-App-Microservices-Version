using EmailDomain.Models;
using EmailDomain.Services.Abstract;
using EmailDomain.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApi.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailApiController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailApiController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Email email)
        {
            _emailService.SendMail(email);
            return Ok(email);
        }
    }
}
