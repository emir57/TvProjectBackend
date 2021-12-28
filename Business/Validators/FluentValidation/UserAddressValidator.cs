using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class UserAddressValidator:AbstractValidator<UserAddres>
    {
        public UserAddressValidator()
        {
            RuleFor(u => u.CityId).NotEmpty();
            RuleFor(u => u.AddressText).NotEmpty();
            RuleFor(u => u.AddressText).MaximumLength(250);
            RuleFor(u => u.UserId).NotEmpty();
        }
    }
}
