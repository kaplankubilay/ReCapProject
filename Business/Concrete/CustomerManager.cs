using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [CacheAspect]
        public IDataResult<IList<Customer>> GetAllCustomers()
        {
            IList<Customer> getCustomers = _customerDal.GetAll();
            return new SuccessDataResult<IList<Customer>>(getCustomers);
        }

        public IDataResult<Customer> GetByIdCustomer(int customerId)
        {
            try
            {
                Customer getCustomer = _customerDal.Get(x => x.Id == customerId);
                return new SuccessDataResult<Customer>(getCustomer);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult UpdateCustomer(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new Result(true,Messages.CustomerUpdated);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult AddCustomer(Customer customer)
        {
            try
            {
                var result = BusinessMotor.Run(CompanyNameLenghtControl(customer), AlreadyExistCompanyName(customer));
                
                if (result != null)
                {
                    return result;
                }

                _customerDal.Add(customer);
                return new Result(true,Messages.CustomerAdded);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult DeleteCustomer(Customer customer)
        {
            try
            {
                Customer deleteCustomer = _customerDal.Get(c => c.Id == customer.Id);
                _customerDal.Delete(deleteCustomer);
                return new Result(true,Messages.CustomerDeleted);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        private IResult AlreadyExistCompanyName(Customer customer)
        {
            bool result = _customerDal.GetAll(x => x.CompanyName == customer.CompanyName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyAxistPropertyName);
            }
            return new SuccessResult();
        }

        private IResult CompanyNameLenghtControl(Customer customer)
        {
            var result = customer.CompanyName.Length;
            if (result <2)
            {
                return new ErrorResult(Messages.LenghtMinControl);
            }
            return new SuccessResult();
        }
    }
}
