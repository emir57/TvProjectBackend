using Core.Entities;
using Core.Entities.Concrete;
using System;

namespace Entities.Dtos
{
    public class OrderDto:IDto
    {
        public int Id { get; set; }
        public User User { get; set; }
        public TvAndPhotoDetailDto Tv { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string AddressText { get; set; }
        public string City { get; set; }
    }
}
