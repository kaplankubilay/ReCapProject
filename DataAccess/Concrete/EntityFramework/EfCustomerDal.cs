﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal:EfEntityRepositoryBase<Customer,CarRentalContext>,ICustomerDal
    {
        public IList<CustomerDetailDto> GetCustomerDetailDtos()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerDetailDto
                    {
                        UserId = customer.UserId,
                        CustomerId = customer.Id,
                        CustomerName = user.FirstName,
                        CustomerLastName = user.LastName,
                        CustomerEmail = user.Email,
                        CompanyName = customer.CompanyName
                    };
                return result.ToList();
            }
        }
    }
}
