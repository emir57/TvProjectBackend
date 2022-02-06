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
        public UserCreditCard UserCreditCard { get; set; }
        public User User { get; set; }
    }
}
