using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        /// <summary>
        /// validation kuralları ctor içerisine yazılır. Validation rules have to writes in the constructor.
        /// </summary>
        public CarValidator()
        {
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            //brandId 3 ise günlük fiyat 49 dan düşük verilemez.
            RuleFor(p => p.DailyPrice).GreaterThan(49).When(p => p.BrandId == 3);
            //olmayan bir kuralı tanımlarsak.. 
            RuleFor(p => p.Description).Must(DontStartX).WithMessage("Aciklama X ile baslayamaz!..");
        }

        /// <summary>
        /// startswith .net in string fonksiyonlarından. 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool DontStartX(string arg)
        {
            bool startX = arg.StartsWith("X") ? false : true;

            return startX;
        }
    }
}
