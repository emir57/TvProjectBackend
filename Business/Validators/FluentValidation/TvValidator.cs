using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class TvValidator:AbstractValidator<Tv>
    {
        public TvValidator()
        {
            RuleFor(t => t.ProductName).NotEmpty();
            RuleFor(t => t.ProductName).MinimumLength(1);
            RuleFor(t => t.ProductName).MaximumLength(50);
            RuleFor(t => t.ProductCode).NotEmpty();
            RuleFor(t => t.ProductCode).MinimumLength(1);
            RuleFor(t => t.ProductCode).MaximumLength(50);
            RuleFor(t => t.ScreenType).NotEmpty();
            RuleFor(t => t.ScreenType).MinimumLength(1);
            RuleFor(t => t.ScreenType).MaximumLength(50);
            RuleFor(t => t.ScreenInch).NotEmpty();
            RuleFor(t => t.ScreenInch).MaximumLength(10);
            RuleFor(t => t.Extras).MaximumLength(50);
            RuleFor(t => t.BrandId).NotEmpty();
            RuleFor(t => t.UnitPrice).NotEmpty();
            RuleFor(t => t.UnitPrice).GreaterThan(0);
        }
    }
}
