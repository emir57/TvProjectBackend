using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class Tv : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ScreenType { get; set; }
        public string ScreenInch { get; set; }
        public string Extras { get; set; }

        public int? BrandId { get; set; }
        [ForeignKey("BrandId")]
        public TvBrand TvBrand { get; set; }

        public decimal UnitPrice { get; set; }
        public byte Discount { get; set; }
        public bool IsDiscount { get; set; }
        public byte Stock { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
