using HoteleriaBack.Domain.Entities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace HoteleriaBack.Api.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public void SendEmail(EmaiilDto request)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.For));
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido
            };

            var smtp = new SmtpClient();

            var host = _configuration.GetSection("Email:Host").Value;
            var enail = Convert.ToInt32(_configuration.GetSection("Email:Port").Value);
            var user = _configuration.GetSection("Email:UserName").Value;
            var pass = _configuration.GetSection("Email:PassWord").Value;
            smtp.Connect(
                _configuration.GetSection("Email:Host").Value,
                Convert.ToInt32(_configuration.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls);

            smtp.Authenticate(_configuration.GetSection("Email:UserName").Value, 
                _configuration.GetSection("Email:PassWord").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
