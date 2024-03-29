﻿using Core.Entities;

namespace Entities.Dtos
{
    public class TvAndPhotoDto:IDto
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
        public string ImageUrl { get; set; }
        public byte Stock { get; set; }
    }
}
