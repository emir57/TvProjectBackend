using Core.Entities.Dtos;
using FluentValidation;

namespace Business.Validators.FluentValidation
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(1);
            RuleFor(u => u.FirstName).MaximumLength(50);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(1);
            RuleFor(u => u.LastName).MaximumLength(50);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).MinimumLength(5);
            RuleFor(u => u.Email).MaximumLength(50);
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
