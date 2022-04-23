using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CategoryWithCountDto : IDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
}
