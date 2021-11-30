using Core.Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class UserForLoginDtoValidator:AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(5);
            RuleFor(u => u.Email).MaximumLength(50);
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
        }
    }
}
