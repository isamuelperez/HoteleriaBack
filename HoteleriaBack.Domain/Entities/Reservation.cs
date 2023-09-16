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
        public Hotel Hotel { get; private set; }
        public Client Client { get; private set; }
        public User User { get; private set; }
        public DateTime InitDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int PersonCount { get; private set; }
    }
}
