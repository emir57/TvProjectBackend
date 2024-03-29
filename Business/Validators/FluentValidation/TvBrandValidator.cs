﻿using Entities.Concrete;
using FluentValidation;

namespace Business.Validators.FluentValidation
{
    public class TvBrandValidator : AbstractValidator<TvBrand>
    {
        public TvBrandValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Name).MaximumLength(50);
        }
    }
}
