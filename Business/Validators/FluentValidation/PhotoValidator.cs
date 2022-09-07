using Entities.Concrete;
using FluentValidation;

namespace Business.Validators.FluentValidation
{
    public class PhotoValidator : AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(p => p.ImageUrl).NotEmpty();
            RuleFor(p => p.ImageUrl).MaximumLength(250);
        }
    }
}
