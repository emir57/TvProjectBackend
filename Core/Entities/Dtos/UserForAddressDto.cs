namespace Core.Entities.Dtos
{
    public class UserForAddressDto:IDto
    {
        public int UserId { get; set; }
        public string AddressText { get; set; }
        public int CityId { get; set; }
    }
}
