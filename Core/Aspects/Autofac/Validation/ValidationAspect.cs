using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.ValidationTool;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    /// <summary>
    /// "aspect" metodun başında-sonunda-hata verdiğinde, çalışacak yapıdır.
    /// </summary>
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //"IsAssignableFrom" atanabilir bir tip mi?
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değildir!");
            }

            _validatorType = validatorType;
        }
        /// <summary>
        /// Validation metot başında çalışır. Bu nedenle "OnBefore" metodunu (metot başında çalışacağı için) override ediyoruz. 
        /// </summary>
        /// <param name="invocation"></param>
        protected override void OnBefore(IInvocation invocation)
        {
            //"validator" instece ı alınan bir nesnenin reflection ile metotlarını tutuyor.
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //örn Car nesnesinin yakalandığı yer... Attribute te verilen ilk arguman ı yakala.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
