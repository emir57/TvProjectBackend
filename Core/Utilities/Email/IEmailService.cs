using System.Threading.Tasks;

namespace Core.Utilities.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}
