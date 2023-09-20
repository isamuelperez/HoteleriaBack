using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Enums;
using HoteleriaBack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class Hotel : Entity
    {
        public string Name { get; private set; }
        public User User { get; private set; }
        public string Image { get; private set; }
        public bool Enabled { get; private set; }
        public Location Location { get; private set; }
        public List<Room> Rooms { get; private set; }
        public Hotel(HotelDTO dto)
        {
            var response = createValidate(dto);
            if (!string.IsNullOrEmpty(response)) throw new Exception(response);

            Name = dto.Name;
            User = dto.User;
            Image = dto.Image;
            Location = dto.Location;
            Enabled = dto.Enabled;

            Rooms = new List<Room>();
        }
        public Hotel()
        {
            Rooms = new List<Room>();
        }
        private string createValidate(HotelDTO dto)
        {
            if (dto is null) return ("El hotel no puede ser nulo.");
            if (dto.User is null || dto.User.Id <= 0) return ("La agencia de viajes no puede ser nulo.");
            if (dto.User.Type != UserType.Agency) return ("El usuario no tiene permisos para crear un hotel.");
            if (string.IsNullOrEmpty(dto.Name)) return ("El nombre no puede ser nulo o vacío.");
            if (string.IsNullOrEmpty(dto.Image)) return ("La imagen no puede ser nula o vacía.");
            if (dto.Location is null) return ("La localización no puede ser nula.");
            return"";
        }


    }
    public class HotelDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public string Image { get; set; }
        public Location Location { get; set; }
        public bool Enabled { get; set; }
    }
}
