using Core.Entities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Dtos
{
    public class TvAndPhotoDetailDto:IDto
    {
        
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ScreenType { get; set; }
        public string ScreenInch { get; set; }
        public string Extras { get; set; }
        public int BrandId { get; set; }
        public decimal UnitPrice { get; set; }
        public byte Discount { get; set; }
        public bool IsDiscount { get; set; }
        public List<Photo> Photos { get; set; }
        public byte Stock { get; set; }
    }
}
