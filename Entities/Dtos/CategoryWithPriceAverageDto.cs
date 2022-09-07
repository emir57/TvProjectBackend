using Core.Entities;

namespace Entities.Dtos
{
    public class CategoryWithPriceAverageDto : IDto
    {
        public string Name { get; set; }
        public decimal PriceAverage { get; set; }
    }
}
