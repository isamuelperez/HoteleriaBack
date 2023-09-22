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
        public string Phone { get; private set; }
        public string BirthDate { get; private set; }
        public Client(ClientDto dto)
        {
            Name = dto.Name;
            Email = dto.Email;
            Phone = dto.Phone;
            BirthDate = dto.BirthDate;
            Gender = dto.Gender;
            NumberDocument = dto.NumberDocument;
            DocumentType = dto.DocumentType;
            Surname = dto.Surname;
        }
        public Client()
        {
            
        }
    }

    public class ClientDto
    {
        public DocumentType DocumentType { get; set; }
        public string NumberDocument { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
    }

}
