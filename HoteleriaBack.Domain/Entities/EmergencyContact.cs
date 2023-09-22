using HoteleriaBack.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Entities
{
    public class EmergencyContact : Entity
    {
        public string FullName { get; private set; }
        public string NumberContact { get; private set; }
        public EmergencyContact(EmergencyContactDto dto)
        {
            FullName = dto.FullName;
            NumberContact = dto.NumberContact;
        }
        public EmergencyContact()
        {
            
        }
    }

    public class EmergencyContactDto
    {
        public string FullName { get; set; }
        public string NumberContact { get; set; }
    }
}

