using HoteleriaBack.Api.Services;
using HoteleriaBack.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public IActionResult SendEmail(EmaiilDto request)
        {
            try
            {
                _emailService.SendEmail(request);
                return Ok();
            }
            catch (Exception e )
            {

                throw e;
            }
        }
    }
}
