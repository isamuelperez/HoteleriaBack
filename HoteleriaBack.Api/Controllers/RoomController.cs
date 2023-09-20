using HoteleriaBack.Application.Rooms.Create;
using HoteleriaBack.Application.Rooms.GetAll;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/Room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public RoomController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }
        //[Authorize]
        [HttpPost("create")]
        public ActionResult Create(CreateRequestRoom request)
        {
            var response = new CreateCommand(_unitOfWork, _authenticationService).Handle(request);
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }

        //[Authorize]
        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var response = new GetAllQueryRoom(_unitOfWork, _authenticationService).Handle();
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
