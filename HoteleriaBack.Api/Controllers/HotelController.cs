using HoteleriaBack.Application.Hotels.Create;
using HoteleriaBack.Domain.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HoteleriaBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public HotelController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("create")]
        public ActionResult Create(CreateRequest request)
        {
            var response = new CreateCommand(_unitOfWork).Handle(request);
            if(response.Status == 200) 
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("getAll")]

        public ActionResult GetAll()
        {
            
        }
    }
}
