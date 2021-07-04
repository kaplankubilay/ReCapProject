using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.ValidationTool
{
    public static class ValidationTool
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="validator">Doğrulama kurallarının olduğu class</param>
        /// <param name="entity">Doğrulanacak entity</param>
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
