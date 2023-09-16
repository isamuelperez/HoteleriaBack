using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class User: Entity
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public UserType Type { get; private set; }
    }
}
