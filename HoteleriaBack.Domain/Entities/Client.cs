using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class Client: Entity
    {
        public DocumentType DocumentType { get; private set; }
        public string NumberDocument { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Gender Gender { get; private set; }
        public string Email { get; private set; }
    }
}
