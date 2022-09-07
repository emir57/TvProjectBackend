using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Core.Utilities.Email
{
    public class SmtpEmailSender : IEmailService
    {
        public IConfiguration Configuration { get; }
        private EmailSettings _emailSettings;
        public SmtpEmailSender(IConfiguration configuration)
        {
            Configuration = configuration;
            _emailSettings = Configuration.GetSection("EmailSettings").Get<EmailSettings>();
        }
        public Task SendEmailAsync(string email, string subject, string body)
        {
            var client = new SmtpClient(_emailSettings.Server, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSsl
            };
            return client.SendMailAsync(
                new MailMessage(_emailSettings.Username, email, subject, body) { IsBodyHtml = true }
                );
        }
    }
}
