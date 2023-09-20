using HoteleriaBack.Domain.Entities;
using HoteleriaBack.Domain.Enums;
using HoteleriaBack.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Hotels.GetAll
{
    public class GetAllResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool Enabled { get; set; }
        public Location Location { get; set; }

        public List<RoomResponse> Rooms { get; set; }
    }


    public class RoomResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Duty { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
        public int MaxCount { get; set; }
    }
}
