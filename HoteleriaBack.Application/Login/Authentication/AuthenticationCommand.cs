using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoteleriaBack.Application.Login.Authentication
{
    public class AuthenticationCommand
    {
        private readonly IJwtService _jwtService;
        private readonly IUnitOfWork _UnitOfWork;
        public AuthenticationCommand(IUnitOfWork UnitOfWork, IJwtService jwtService)
        {
            _UnitOfWork = UnitOfWork;
            _jwtService = jwtService;
        }

        public Response<AuthenticationResponse> Handle(AuthenticationRequest request)
        {
            _UnitOfWork.BeginTransaction();

            var user = _UnitOfWork.GenericRepository<User>().FindBy( x => x.UserName == request.UserName 
            && x.Password == request.Password).FirstOrDefault();
            if (user is null)
                return new Response<AuthenticationResponse>("Usuario y/o clave incorrecta.", 400);

            var response = new AuthenticationResponse();
            response.UserName = user.UserName;
            response.UserId = user.Id;
            response.Type = user.Type;
            response.Token = _jwtService.GetToken(user);
            return new Response<AuthenticationResponse>("Se consultó correctamente.", response);


        }
        
    }
}
