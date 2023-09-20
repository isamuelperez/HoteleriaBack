using HoteleriaBack.Application.Hotels.GetAll;
using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Rooms.GetAll
{
    public class GetAllQueryRoom
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public GetAllQueryRoom(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
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
                if (user.Type == UserType.Agency)
                {
                    rooms = _unitOfWork.GenericRepository<Room>().GetAll().ToList();
                }
                else
                {
                    rooms = _unitOfWork.GenericRepository<Room>().GetAll().ToList();
                }

                if (!rooms.Any()) return new Response<List<GetAllRoomResponse>>("No tiene habitacones por mostrar.", 400);

                var getAll = rooms.Select(x => MapHotel(x)).ToList();

                return new Response<List<GetAllRoomResponse>>("Se consultó correctamente.",getAll);
            }
            catch (Exception)
            {

                return new Response<List<GetAllRoomResponse>>("Hubo un error en el sistema.", 500);
            }

        }

        private GetAllRoomResponse MapHotel(Room room)
        {
            var response = new GetAllRoomResponse();
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
