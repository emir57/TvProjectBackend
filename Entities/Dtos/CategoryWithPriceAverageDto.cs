using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryWithPriceAverageDto : IDto
    {
        public int Name { get; set; }
        public int PriceAverage { get; set; }
    }
}
