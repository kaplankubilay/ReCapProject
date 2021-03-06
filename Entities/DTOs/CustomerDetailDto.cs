using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDto:IDto
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CompanyName { get; set; }
    }
}
