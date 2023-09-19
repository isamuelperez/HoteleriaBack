using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HoteleriaBack.Api.Services
{
    public class AutheticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AutheticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public int GetIdUser()
        {
            var token = GetToken();
            if (token == null)
                return 0;
            var id = token.Claims.First(x => x.Type == ClaimTypes.Sid).Value;
            return int.Parse(id);
        }

        public int GetRolUser()
        {
            var token = GetToken();
            if (token == null)
                return -1;
            var rol = token.Claims.First(x => x.Type == "role").Value;
            if (rol.Equals("Traveler"))
                return (int)UserType.Traveler;
            else
                return (int)UserType.Agency;

        }

        private JwtSecurityToken GetToken()
        {
            var token = _httpContextAccessor.HttpContext.Request.Headers.Where(x => x.Key.Equals("Authorization"))?.Select(x => x.Value).FirstOrDefault().FirstOrDefault();
            if (token == null)
                return null;
            token = token.Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            return handler.ReadJwtToken(token);

        }
    }
}
