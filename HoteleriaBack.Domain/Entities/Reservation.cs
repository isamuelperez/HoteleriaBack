using HoteleriaBack.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class Reservation: Entity
    {
        public Room Room { get; private set; }
        public Client Client { get; private set; }
        public User User { get; private set; }
        public EmergencyContact EmergencyContact { get; private set; }
        public DateTime InitDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int PersonCount { get; private set; }
        public Reservation()
        {
            
        }
        public Reservation(ReservationDto dto)
        {
            Room = dto.Room;
            Client = dto.Client;
            User = dto.User;
            EmergencyContact = dto.EmergencyContact;
            InitDate = dto.InitDate;
            EndDate = dto.EndDate;
            PersonCount = dto.PersonCount;
                
        }

    }

    public class ReservationDto
    {
        public Client Client { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public EmergencyContact EmergencyContact { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonCount { get; set; }
    }
}
