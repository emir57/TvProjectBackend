using Core.Entities;

namespace Entities.Dtos
{
    public class UpdateUserDto:IDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}
