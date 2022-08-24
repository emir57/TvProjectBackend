using Core.Entities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class TvBrand : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public ICollection<Tv> Tvs { get; set; }
    }
}
