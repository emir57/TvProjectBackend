using Core.Entities;
using Core.Entities.Concrete;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class UserCreditCard : IEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string Date { get; set; }
    }
}
