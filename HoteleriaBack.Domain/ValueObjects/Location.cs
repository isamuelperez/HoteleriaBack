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
    }
}
