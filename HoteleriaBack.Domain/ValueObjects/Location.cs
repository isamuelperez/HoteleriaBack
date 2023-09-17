using HoteleriaBack.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.ValueObjects
{
    public class Location: Entity
    {
        public string City { get; private set; }
        public string Address { get; private set; }

        public Location(string city, string address)
        {
            if(string.IsNullOrEmpty(city)) throw new Exception("La ciudad no puede ser vacía o nula.");
            if (string.IsNullOrEmpty(address)) throw new Exception("La dirección no puede ser vacía o nula.");

            Address = address;
            City = city;
        }
        public Location()
        {
            
        }
    }
}
