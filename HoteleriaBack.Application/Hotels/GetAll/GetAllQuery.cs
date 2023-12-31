﻿using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HoteleriaBack.Application.Hotels.GetAll
{
    public class GetAllQuery
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public GetAllQuery(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        public Response<List<GetAllResponse>> Handle()
        {
            long userId = 1;//_authenticationService.GetIdUser();

            if (userId <= 0) return new Response<List<GetAllResponse>>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<List<GetAllResponse>>("No se pudo encontrar el usuario.", 500);
            try
            {
                var hotels = new List<Hotel>();
                if (user.Type == UserType.Agency)
                {
                    hotels = _unitOfWork.GenericRepository<Hotel>().FindBy(x => 
                    x.User.Id == userId, includeProperties: "Location").ToList();
                }
                else
                {
                    hotels = _unitOfWork.GenericRepository<Hotel>().FindBy(includeProperties: "Location").ToList();
                }

                if (!hotels.Any()) return new Response<List<GetAllResponse>>("No tiene hoteles por mostrar.", 400);

                var getAll = new List<GetAllResponse>();
                hotels.ForEach(x =>
                {
                    var r = MapHotel(x);
                    var rooms = _unitOfWork.GenericRepository<Room>().FindBy(y=> y.Hotel.Id == x.Id).ToList();

                    if (rooms.Any())
                    {
                        r.Rooms= rooms.Select(z=> MapRoom(z)).ToList();
                    }
                    else
                    {
                        r.Rooms = new List<RoomResponse>();
                    }
                    getAll.Add(r);
                });

                return new Response<List<GetAllResponse>>("Se consultó correctamente.", getAll);
            }
            catch (Exception)
            {

                return new Response<List<GetAllResponse>>("Hubo un error en el sistema.", 500);
            }

            
        }
        private GetAllResponse MapHotel(Hotel hotel)
        {
            var response = new GetAllResponse();
            response.Id = hotel.Id;
            response.Name = hotel.Name;
            response.Image = hotel.Image;
            response.Enabled = hotel.Enabled;
            response.Location = hotel.Location;
            return response;
            
        }
        private RoomResponse MapRoom(Room room)
        {
            var response = new RoomResponse();
            response.Id = room.Id;
            response.Name = room.Name;
            response.BaseCost = room.BaseCost;
            response.Duty = room.Duty;
            response.Type = MapType.MapRoomType(room.Type);
            response.Location = room.Location;
            response.Enabled = room.Enabled;
            response.MaxCount = room.MaxCount;
            return response;
        }
    }
}
