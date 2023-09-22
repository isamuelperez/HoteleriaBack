using HoteleriaBack.Application.Rooms.Update;
using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Reservations.Create
{
    public class CreateReservationRequest
    {

        public long RoomId { get; set; }
        public ClientRequest Client { get; set; }
        public EmergencyContactRequest EmergencyContact { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PersonCount { get; set; }

        public UpdateRoomRequest UpdateRoomRequest { get; set; }
    }


    public class ClientRequest
    {
        public DocumentType DocumentType { get; set; }
        public string NumberDocument { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
    }

    public class EmergencyContactRequest
    {
        public string FullName { get; set; }
        public string NumberContact { get; set; }
    }
}
