using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserCreditCard:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string Date { get; set; }
    }
}
