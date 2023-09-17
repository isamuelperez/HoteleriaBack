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
        public string Name { get; private set; }
        public decimal BaseCost { get; private set; }
        public decimal Duty { get; private set; }
        public RoomType Type { get; private set; }
        public string Location { get; private set; }
        public bool Enabled { get; private set; }
        public int MaxCount { get; private set; }
        public Room() { }
    }
}
