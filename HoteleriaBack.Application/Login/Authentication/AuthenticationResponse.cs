using HoteleriaBack.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Login.Authentication
{
    public class AuthenticationResponse
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public UserType Type { get; set; }
        public string Token { get; set; }
    }
}
