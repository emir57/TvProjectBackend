using Core.Entities;

namespace Entities.Dtos
{
    public class SendCodeDto :IDto
    {
        public int UserId { get; set; }
    }
}
