using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Domain.Contracts
{
    public interface IAuthenticationService
    {
        int GetIdUser();
        int GetRolUser();
    }
}
