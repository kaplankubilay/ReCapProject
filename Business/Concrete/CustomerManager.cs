using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

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
                throw new Exception("GetByIdCustomer calismadi.",exception);
            }
        }

        public IResult UpdateCustomer(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
                return new Result(true,Messages.CustomerUpdated);
            }
            catch (Exception exception)
            {
                throw new Exception("",exception);
            }
        }

        public IResult AddCustomer(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
                return new Result(true,Messages.CustomerAdded);
            }
            catch (Exception exception)
            {
                throw new Exception("", exception);
            }
        }

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
                throw new Exception("", exception);
            }
        }
    }
}
