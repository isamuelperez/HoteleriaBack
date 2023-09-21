using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class Room : Entity
    {
        public Hotel Hotel { get; private set; }
        public string Name { get; private set; }
        public decimal BaseCost { get; private set; }
        public decimal Duty { get; private set; }
        public RoomType Type { get; private set; }
        public string Location { get; private set; }
        public bool Enabled { get; private set; }
        public int MaxCount { get; private set; }
        public Room()
        {

        }

        public Room(RoomDto dto)
        {

            Name = dto.Name;
            BaseCost = dto.BaseCost;
            Duty = dto.Duty;
            Type = dto.Type;
            Location = dto.Location;
            Enabled = dto.Enabled;
            MaxCount = dto.MaxCount;

        }

        public void Update(RoomDto dto)
        {
            Hotel = dto.Hotel;
            Name = dto.Name;
            BaseCost = dto.BaseCost;
            Duty = dto.Duty;
            Type = dto.Type;
            Location = dto.Location;
            Enabled = dto.Enabled;
            MaxCount = dto.MaxCount;
        }
    }

    public class RoomDto
    {
        public Hotel Hotel { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Duty { get; set; }
        public RoomType Type { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
        public int MaxCount { get; set; }
    }
}
