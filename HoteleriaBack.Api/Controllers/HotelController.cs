using HoteleriaBack.Application.Hotels.Create;
using HoteleriaBack.Application.Hotels.GetAll;
using HoteleriaBack.Application.Hotels.Update;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public HotelController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }
        [Authorize]
        [HttpPost("create")]
        public ActionResult Create(CreateRequest request)
        {
            var response = new CreateCommand(_unitOfWork, _authenticationService).Handle(request);
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }

        [Authorize]
        [HttpPut("update")]
        public ActionResult Update(UpdateRequest request)
        {
            var response = new UpdateCommand(_unitOfWork, _authenticationService).Handle(request);
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }

        //[Authorize]
        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var response = new GetAllQuery(_unitOfWork, _authenticationService).Handle();
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
