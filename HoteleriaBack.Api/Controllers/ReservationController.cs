using HoteleriaBack.Application.Hotels.Create;
using HoteleriaBack.Application.Reservations.Create;
using HoteleriaBack.Application.Reservations.GetAll;
using HoteleriaBack.Application.Rooms.GetAll;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public ReservationController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }
        //[Authorize]
        [HttpPost("create")]
        public ActionResult Create(CreateReservationRequest request)
        {
            var response = new CreateReservationCommand(_unitOfWork, _authenticationService).Handle(request);
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }

        //[Authorize]
        [HttpGet("getAll")]
        public ActionResult GetAll()
        {
            var response = new GetAllQueryReservation(_unitOfWork, _authenticationService).Handle();
            if (response.Status == 200)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
