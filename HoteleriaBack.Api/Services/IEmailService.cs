using HoteleriaBack.Domain.Entities;

namespace HoteleriaBack.Api.Services
{
    public interface IEmailService
    {
        void SendEmail(EmaiilDto request);
    }
}
