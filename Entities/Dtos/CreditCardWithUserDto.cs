using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CreditCardWithUserDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
