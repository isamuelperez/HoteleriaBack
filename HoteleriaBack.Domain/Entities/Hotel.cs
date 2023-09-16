using HoteleriaBack.Domain.Contracts;
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
        public Hotel()
        {

        }
    }
}
