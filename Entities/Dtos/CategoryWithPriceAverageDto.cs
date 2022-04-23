using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryWithPriceAverageDto : IDto
    {
        public string Name { get; set; }
        public decimal PriceAverage { get; set; }
    }
}
