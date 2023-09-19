using HoteleriaBack.Application.Login.Authentication;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        private readonly IAuthenticationService _authenticationService;
        public UserController(IUnitOfWork unitOfWork, IJwtService jwtService, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
            _authenticationService = authenticationService;
        }
        [HttpPost("authentication")]
        public ActionResult Authentication(AuthenticationRequest request)
        {
            var response = new AuthenticationCommand(_unitOfWork,_jwtService).Handle(request);
            if(response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
