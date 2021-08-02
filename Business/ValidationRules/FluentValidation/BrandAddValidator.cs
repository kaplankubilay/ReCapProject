using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandAddValidator:AbstractValidator<Brand>
    {
        public BrandAddValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
        }
    }
}
