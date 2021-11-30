using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class PhotoValidator:AbstractValidator<Photo>
    {
        public PhotoValidator()
        {
            RuleFor(p => p.ImageUrl).NotEmpty();
            RuleFor(p => p.ImageUrl).MaximumLength(250);
        }
    }
}
