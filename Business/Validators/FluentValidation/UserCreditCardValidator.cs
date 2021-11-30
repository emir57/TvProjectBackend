using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class UserCreditCardValidator:AbstractValidator<UserCreditCard>
    {
        public UserCreditCardValidator()
        {
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.CreditCardNumber).NotEmpty();
            RuleFor(u => u.CreditCardNumber).CreditCard();
            RuleFor(u => u.CVV).NotEmpty();
            RuleFor(u => u.CVV).MaximumLength(4);
            RuleFor(u => u.Date).MaximumLength(5);
        }
    }
}
