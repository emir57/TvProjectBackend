using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class UserAddress : IEntity
    {
        public int Id { get; set; }
        public string AddressName { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string AddressText { get; set; }

        public byte? CityId { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }

        public DateTime? DeletedDate { get; set; }

        public UserAddress(int id, string addressName, int userId, string addressText, byte? cityId)
        {
            Id = id;
            AddressName = addressName;
            UserId = userId;
            AddressText = addressText;
            CityId = cityId;
        }
    }
}
