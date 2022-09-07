namespace Core.Entities.Dtos
{
    public class UserForCreditCardDto:IDto
    {
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string Date { get; set; }
    }
}
