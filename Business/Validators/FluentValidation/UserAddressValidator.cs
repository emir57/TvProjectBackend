using Entities.Concrete;
using FluentValidation;

namespace Business.Validators.FluentValidation
{
    public class UserAddressValidator : AbstractValidator<UserAddress>
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
