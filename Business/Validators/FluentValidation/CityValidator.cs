using Entities.Concrete;
using FluentValidation;

namespace Business.Validators.FluentValidation
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(c => c.CityName).NotEmpty();
            RuleFor(c => c.CityName).MinimumLength(1);
            RuleFor(c => c.CityName).MaximumLength(70);
        }
    }
}
