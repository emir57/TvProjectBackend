using Core.Entities;

namespace Entities.Dtos
{
    public class VerfiyCodeDto : IDto
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
