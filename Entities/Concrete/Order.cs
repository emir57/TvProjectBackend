using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int? TvId { get; set; }
        [ForeignKey("TvId")]
        public Tv Tv { get; set; }

        public DateTime ShippedDate { get; set; }
        public decimal TotalPrice { get; set; }

        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public UserAddress UserAddress { get; set; }
    }
}
