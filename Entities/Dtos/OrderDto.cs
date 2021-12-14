using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDto:IDto
    {
        public User User { get; set; }
        public TvAndPhotoDto Tv { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string AddressText { get; set; }
        public string City { get; set; }
    }
}
