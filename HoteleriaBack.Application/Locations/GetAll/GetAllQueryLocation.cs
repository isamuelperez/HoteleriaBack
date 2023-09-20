using HoteleriaBack.Application.Hotels.GetAll;
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

namespace HoteleriaBack.Application.Locations.GetAll
{
    public class GetAllqueryLocation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public GetAllqueryLocation(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        public Response<List<GetAllLocationResponse>> Handle()
        {
            long userId = 1;//_authenticationService.GetIdUser();

            if (userId <= 0) return new Response<List<GetAllLocationResponse>>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<List<GetAllLocationResponse>>("No se pudo encontrar el usuario.", 500);
            try
            {
                var locations = new List<Location>();
                if (user.Type == UserType.Agency || user.Type == UserType.Traveler)
                {
                    locations = _unitOfWork.GenericRepository<Location>().GetAll().ToList();
                }

                if (!locations.Any()) return new Response<List<GetAllLocationResponse>>("No tiene hoteles por mostrar.", 400);

                var getAll = locations.Select(x => MapLocation(x)).ToList();
                return new Response<List<GetAllLocationResponse>>("Se consultó correctamente.", getAll);
            }
            catch (Exception)
            {

                return new Response<List<GetAllLocationResponse>>("Hubo un error en el sistema.", 500);
            }


        }
        private GetAllLocationResponse MapLocation(Location location)
        {
            var response = new GetAllLocationResponse();
            response.Id = location.Id;
            response.City = location.City;
            response.Address = location.Address;
            return response;

        }
    }
}
