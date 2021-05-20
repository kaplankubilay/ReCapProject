using System;
using Business.Concrete;
using DataAccess.Concrete;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new CarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            var getCarById = carManager.GetById(1);
            Console.WriteLine(getCarById.ModelYear);

        }
    }
}
