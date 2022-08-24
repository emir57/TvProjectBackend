using Core.Entities;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public byte Id { get; set; }
        public string CityName { get; set; }
    }
}
