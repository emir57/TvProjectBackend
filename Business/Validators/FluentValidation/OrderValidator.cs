using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(o => o.UserId).NotEmpty().NotNull();
            RuleFor(o => o.TvId).NotEmpty().NotNull();
            RuleFor(o => o.TotalPrice).NotEmpty().NotNull();
        }
    }
}
