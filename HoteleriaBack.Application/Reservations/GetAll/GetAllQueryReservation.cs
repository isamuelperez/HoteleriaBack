using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;

namespace HoteleriaBack.Application.Reservations.GetAll
{
    public class GetAllQueryReservation
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;
        public GetAllQueryReservation(IUnitOfWork unitOfWork, IAuthenticationService authenticationService)
        {
            _unitOfWork = unitOfWork;
            _authenticationService = authenticationService;
        }

        public Response<List<GetAllResponseReservation>> Handle()
        {
            long userId =_authenticationService.GetIdUser();

            if (userId <= 0) return new Response<List<GetAllResponseReservation>>("El usuario no esta utenticado.", 500);

            var user = _unitOfWork.GenericRepository<User>().Find(userId);

            if (user is null) return new Response<List<GetAllResponseReservation>>("No se pudo encontrar el usuario.", 500);
            try
            {
                var reservations = new List<Reservation>();
                if (user.Type == UserType.Agency)
                {
                    reservations = _unitOfWork.GenericRepository<Reservation>().FindBy(includeProperties: "Room,Client,EmergencyContact").ToList();
                }

                if (!reservations.Any()) return new Response<List<GetAllResponseReservation>>("No tiene habitacones por mostrar.", 400);

                var getAll = reservations.Select(x =>
                {
                    var room = _unitOfWork.GenericRepository<Room>().FindBy(y => y.Id == x.Room.Id, includeProperties: "Hotel").FirstOrDefault();
                    var hotel = _unitOfWork.GenericRepository<Hotel>().FindBy(z => z.Id == room.Hotel.Id, includeProperties: "Location,User").FirstOrDefault();
                    
                    var roomReservation = MapRoomReservation(room);
                    var hotelReservation = MapHotelReservation(hotel);
                    var userReservation = MapUserReservation(hotel.User);

                    hotelReservation.Room = roomReservation;

                    var reservacion = MapReservation(x);
                    reservacion.Hotel = hotelReservation;
                    reservacion.User = userReservation;
                    return reservacion;

                }).ToList();

                return new Response<List<GetAllResponseReservation>>("Se consultó correctamente.", getAll);
            }
            catch (Exception)
            {

                return new Response<List<GetAllResponseReservation>>("Hubo un error en el sistema.", 500);
            }

        }

        
        private GetAllResponseReservation MapReservation(Reservation reservation)
        {
            var response = new GetAllResponseReservation();
            response.Id = reservation.Id;
            response.EmergencyContact = reservation.EmergencyContact;
            response.Client = reservation.Client;
            response.InitDate = reservation.InitDate;
            response.EndDate = reservation.EndDate;
            response.PersonCount = reservation.PersonCount;
            return response;

        }

        private HotelReservation MapHotelReservation(Hotel hotel)
        {
            var response = new HotelReservation();

            response.Location= hotel.Location;
            response.Name= hotel.Name;
            response.Id= hotel.Id;
            response.Image = hotel.Image;

            return response;

        }

        private UserReservetaion MapUserReservation(User user)
        {
            return new UserReservetaion() { UserName=user.UserName};

        }

        private RoomReservation MapRoomReservation(Room room)
        {
            var response = new RoomReservation();

            response.Location = room.Location;
            response.Name = room.Name;
            response.Id = room.Id;
            response.BaseCost = room.BaseCost;
            response.Duty = room.Duty;
            response.Type = room.Type;
            response.MaxCount = room.MaxCount;

            return response;

        }


    }

    public class HotelResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }


        public HotelResponseDto(Hotel dto)
        {
            Id = dto.Id;
            Name = dto.Name;
        }
        public HotelResponseDto()
        {
        }
    }
}

