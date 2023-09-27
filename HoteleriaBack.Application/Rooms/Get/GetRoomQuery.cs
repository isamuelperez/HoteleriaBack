using HoteleriaBack.Application.Rooms.GetAll;
using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Rooms.Get
{
    public class GetRoomQuery
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public bool Enabled { get; set; }
        public GetRoomQuery(IUnitOfWork unitOfWork, IAuthenticationService authenticationService, bool enabled)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
            this.Enabled = enabled;
        }

        public Response<List<GetAllRoomResponse>> Handle()
        {
            long userId = 1;//_authenticationService.GetIdUser();

            if (userId <= 0) return new Response<List<GetAllRoomResponse>>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<List<GetAllRoomResponse>>("No se pudo encontrar el usuario.", 500);
            try
            {
                var rooms = new List<Room>();
                rooms = _unitOfWork.GenericRepository<Room>().FindBy(x => x.Enabled == this.Enabled, includeProperties: "Hotel").ToList();

                if (!rooms.Any()) return new Response<List<GetAllRoomResponse>>("No tiene habitacones por mostrar.", 400);

                var getAll = rooms.Select(x => MapHotel(x)).ToList();

                return new Response<List<GetAllRoomResponse>>("Se consultó correctamente.", getAll);
            }
            catch (Exception)
            {

                return new Response<List<GetAllRoomResponse>>("Hubo un error en el sistema.", 500);
            }

        }

        private GetAllRoomResponse MapHotel(Room room)
        {
            var response = new GetAllRoomResponse();
            response.Hotel = new HotelResponseDto(room.Hotel);
            response.Id = room.Id;
            response.Name = room.Name;
            response.Type = room.Type;
            response.Duty = room.Duty;
            response.BaseCost = room.BaseCost;
            response.MaxCount = room.MaxCount;
            response.Enabled = room.Enabled;
            response.Location = room.Location;
            return response;

        }

    }
}

