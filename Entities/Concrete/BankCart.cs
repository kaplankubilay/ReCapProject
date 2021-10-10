using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class BankCart:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double CartNo { get; set; }
        public int Password { get; set; }
    }
}
