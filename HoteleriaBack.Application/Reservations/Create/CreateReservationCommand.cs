using HoteleriaBack.Application.Hotels.Create;
using HoteleriaBack.Application.Rooms.Update;
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

namespace HoteleriaBack.Application.Reservations.Create
{
    public class CreateReservationCommand
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public CreateReservationCommand(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        public Response<bool> Handle(CreateReservationRequest request)
        {
            _unitOfWork.BeginTransaction();

            if (request is null) return new Response<bool>("La solicitud no puede ser nula.", 400);

            long userId = _authenticationService.GetIdUser();

            if (userId < 0) return new Response<bool>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<bool>("No se pudo encontrar el usuario.", 500);


            try
            {
                var room = _unitOfWork.GenericRepository<Room>().Find(request.RoomId);
                var reservationDto = Map(request);
                reservationDto.User = user;
                reservationDto.Room = room;
                reservationDto.EmergencyContact = MapEmergencyContact(request);
                reservationDto.Client = MapClient(request);
                var reservation = new Reservation(reservationDto);

                _unitOfWork.GenericRepository<Reservation>().Add(reservation);

                var HotelSelect = _unitOfWork.GenericRepository<Hotel>().Find(request.UpdateRoomRequest.HotelId);
                var dto = Map(request.UpdateRoomRequest, HotelSelect);

                room.Update(dto);

                _unitOfWork.GenericRepository<Room>().Update(room);
                _unitOfWork.Commit();

                return new Response<bool>("Se creó correctamente la reservacion.", 200);

            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                return new Response<bool>(e.Message, 500);
            }

        }

        private RoomDto Map(UpdateRoomRequest request, Hotel hotel)
        {
            var dto = new RoomDto();
            dto.Hotel = hotel;
            dto.Name = request.Name;
            dto.Enabled = request.Enabled;
            dto.Location = request.Location;
            dto.Type = request.Type;
            dto.Duty = request.Duty;
            dto.BaseCost = request.BaseCost;
            dto.MaxCount = request.MaxCount;
            return dto;
        }

        private ReservationDto Map(CreateReservationRequest request)
        {
            var dto = new ReservationDto();
            dto.PersonCount = request.PersonCount;
            dto.InitDate = request.InitDate;
            dto.EndDate = request.EndDate;
            return dto;
        }

        private EmergencyContact MapEmergencyContact(CreateReservationRequest request)
        {
            var dto = new EmergencyContactDto();
            dto.NumberContact = request.EmergencyContact.NumberContact;
            dto.FullName = request.EmergencyContact.FullName;

            var emergencyContact = new EmergencyContact(dto);

            return emergencyContact;
        }

        private Client MapClient(CreateReservationRequest request)
        {
            var dto = new ClientDto();
            dto.Phone = request.Client.Phone;
            dto.Name = request.Client.Name;
            dto.NumberDocument = request.Client.NumberDocument;
            dto.Email = request.Client.Email;
            dto.BirthDate = request.Client.BirthDate;
            dto.DocumentType = request.Client.DocumentType;
            dto.Surname = request.Client.Surname;
            dto.Gender = request.Client.Gender;
            var client = new Client(dto);
            return client;
        }
    }
}
