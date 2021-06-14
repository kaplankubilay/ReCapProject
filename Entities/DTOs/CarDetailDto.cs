﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string FuelName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int? ModelYear { get; set; }
    }
}
