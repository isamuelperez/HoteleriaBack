using HoteleriaBack.Application.Shared;
using HoteleriaBack.Domain.Contracts;
using HoteleriaBack.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HoteleriaBack.Api.Services
{
    public class JwtService : IJwtService
    {
        private readonly AppSettings _appSettings;
        public JwtService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GetToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescritor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.Sid,user.Id.ToString()),
                            new Claim(ClaimTypes.NameIdentifier,user.UserName),
                            new Claim(ClaimTypes.Role, user.Type.ToString())
                        }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescritor);
            return tokenHandler.WriteToken(token);
        }
    }
}
