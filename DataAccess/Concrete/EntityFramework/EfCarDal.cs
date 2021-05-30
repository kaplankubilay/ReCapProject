﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal:EfEntityRepositoryBase<Car,CarRentalContext>,ICarDal
    {
        public IList<CarDetailDto> GetCarDetailDtos()
        {
            using (CarRentalContext context= new CarRentalContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands on car.BrandId equals brand.Id
                    join color in context.Colors on car.ColorId equals color.Id
                    join fuel in context.Fuels on car.FuelId equals fuel.Id
                    select new CarDetailDto
                    {
                        CarId = car.Id,
                        BrandName = brand.Name,
                        ColorName = color.Name,
                        Description = car.Description,
                        FuelName = fuel.Name,
                        ModelYear = car.ModelYear
                    };
                return result.ToList();
            }
        }
    }
}
