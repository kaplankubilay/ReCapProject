using System;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.DailyPrice);
            }

            //carManager.AddCar(new Car
            //{
            //    BrandId = 4,
            //    ColorId = 5,
            //    DailyPrice = 175,
            //    Description= "Benzinli",
            //    ModelYear = 2016
            //});

        }
    }
}
