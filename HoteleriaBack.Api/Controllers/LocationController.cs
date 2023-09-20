using HoteleriaBack.Application.Hotels.Create;
using HoteleriaBack.Application.Hotels.GetAll;
using HoteleriaBack.Application.Locations.GetAll;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public LocationController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }
       
        //[Authorize]
        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var response = new GetAllqueryLocation(_unitOfWork, _authenticationService).Handle();
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
