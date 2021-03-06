using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserAddress:IEntity
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public int UserId { get; set; }
        public string AddressText { get; set; }
        public byte CityId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
