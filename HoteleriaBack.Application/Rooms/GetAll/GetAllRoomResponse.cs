using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Rooms.GetAll
{
    public class GetAllRoomResponse
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public decimal BaseCost { get; set; }
        public decimal Duty { get; set; }
        public RoomType Type { get; set; }
        public string Location { get; set; }
        public bool Enabled { get; set; }
        public int MaxCount { get; set; }
    }
}
