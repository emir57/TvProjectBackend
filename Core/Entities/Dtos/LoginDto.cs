using Core.Security.JWT;

namespace Core.Entities.Dtos
{
    public class LoginDto:IDto
    {
        public AccessToken AccessToken { get; set; }
        public LoginingUser User { get; set; }
    }
}
