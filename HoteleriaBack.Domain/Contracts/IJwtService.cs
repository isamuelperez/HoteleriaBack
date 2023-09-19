using HoteleriaBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Contracts
{
    public interface IJwtService
    {
        string GetToken(User user);
    }
}
