using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int FuelId { get; set; }
        public int? ModelYear { get; set; }
        public decimal? DailyPrice { get; set; }
        public string Description { get; set; }
        public string Plate { get; set; }
    }
}
