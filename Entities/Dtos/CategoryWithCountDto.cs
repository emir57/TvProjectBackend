using Core.Entities;

namespace Entities.Dtos
{
    public class CategoryWithCountDto : IDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
