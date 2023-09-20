using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Hotels.Update
{
    public class UpdateRequest
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public bool Enabled { get; set; }
    }
}
