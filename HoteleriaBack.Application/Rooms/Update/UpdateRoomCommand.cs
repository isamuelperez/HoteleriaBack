using HoteleriaBack.Application.Rooms.Create;
using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Rooms.Update
{
    public class UpdateRoomCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public UpdateRoomCommand(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        public Response<bool> Handle(UpdateRoomRequest request)
        {
            _unitOfWork.BeginTransaction();

            if (request is null) return new Response<bool>("La solicitud no puede ser nula.", 400);

            long userId = 1;// _authenticationService.GetIdUser();

            if (userId <= 0) return new Response<bool>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<bool>("No se pudo encontrar el usuario.", 500);

            if (user.Type != UserType.Agency) return new Response<bool>("El usuario no tiene permisos para crear una habitacióm.", 400);

            try
            {
                var roomSelect = _unitOfWork.GenericRepository<Room>().Find(request.Id);
                var dto = Map(request);

                roomSelect.Update(dto);

                _unitOfWork.GenericRepository<Room>().Update(roomSelect);
                _unitOfWork.Commit();

                return new Response<bool>("Se modifico la habitación.", 200);

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                return new Response<bool>(e.Message, 500);
            }

        }

        private RoomDto Map(UpdateRoomRequest request)
        {
            var dto = new RoomDto();
            dto.Name = request.Name;
            dto.Enabled = request.Enabled;
            dto.Location = request.Location;
            dto.Type = request.Type;
            dto.Duty = request.Duty;
            dto.BaseCost = request.BaseCost;
            dto.MaxCount = request.MaxCount;
            return dto;
        }
    }
}
