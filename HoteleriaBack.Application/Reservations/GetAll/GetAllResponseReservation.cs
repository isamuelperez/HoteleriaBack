using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using HoteleriaBack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Reservations.GetAll
{
    public class GetAllResponseReservation
    {
        public long Id { get; set; }
        public UserReservetaion User { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonCount { get; set; }
        public Client Client { get; set; }
        public HotelReservation Hotel { get; set; }

        public EmergencyContact EmergencyContact { get; set; }

    }

    public class UserReservetaion
    {
        public string UserName { get; set; }

    }

    public class RoomReservation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Duty { get; set; }
        public RoomType Type { get; set; }
        public string Location { get; set; }
        public int MaxCount { get; set; }

    }

    public class HotelReservation
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Location Location { get; set; }
        public RoomReservation Room { get; set; }

    }

}
