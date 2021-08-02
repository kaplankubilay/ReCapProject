using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class FuelValidator :AbstractValidator<Fuel>
    {
        public FuelValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MinimumLength(2);
        }
    }
}
