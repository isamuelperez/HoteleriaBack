using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using HoteleriaBack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Hotels.Create
{
    public class CreateCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response<bool> Handle(CreateRequest request)
        {
            _unitOfWork.BeginTransaction();

            if (request is null) return new Response<bool>("La solicitud no puede ser nula.", 400);

            long userId = 1;

            if(userId <= 0) return new Response<bool>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if(user is null) return new Response<bool>("No se pudo encontrar el usuario.", 500);

            if (user.Type != UserType.Agency) return new Response<bool>("El usuario no tiene permisos para crear un hotel.", 400);

            try
            {
                var dto = Map(request);
                dto.User = user;
                dto.Location = new Location(request.City, request.Address);

                var hotel = new Hotel(dto);

                _unitOfWork.GenericRepository<Hotel>().Add(hotel);
                _unitOfWork.Commit();

                return new Response<bool>("Se creó correctamente el hotel.");

            }
            catch (Exception e)
            {

                _unitOfWork.Rollback();
                return new Response<bool>( e.Message, 500);
            }
            

        }

        private HotelDTO Map(CreateRequest request)
        {
            var dto = new HotelDTO();
            dto.Name = request.Name;
            dto.Image = request.Image;
            dto.Enabled = request.Enabled;
            return dto;
        }
    }
}
