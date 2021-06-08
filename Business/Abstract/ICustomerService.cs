using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<IList<Customer>> GetAllCustomers();
        IDataResult<Customer> GetByIdCustomer(int customerId);
        IResult UpdateCustomer(Customer customer);
        IResult AddCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
    }
}
