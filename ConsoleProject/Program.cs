using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            //GetAllBrands();
            //GetByIdBrand();
            //AddBrand();
            //UpdateBrand();
            //DeleteBrand();
            
            //GetAllCar();
            //AddCar();
            //UpdateCar();
            //DeleteCar();
            //GetByIdCar();
        }

        private static void DeleteBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.DeleteBrand(new Brand
            {
                Id = 1002
            });
        }

        private static void UpdateBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.UpdateBrand(new Brand
            {
                Id = 1002,
                Name = "Ford2"
            });
        }

        private static void AddBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.AddBrand(new Brand
            {
                Name = "Ford"
            });
        }

        private static void GetByIdBrand()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand getBrand = brandManager.GetByIdBrand(1);
            Console.WriteLine("id : {0}, name : {1}", getBrand.Id, getBrand.Name);
        }

        private static void GetAllBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAllBrands())
            {
                Console.WriteLine("id : {0}, name : {1}", brand.Id, brand.Name);
            }
        }

        private static void GetByIdCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car getCar = carManager.GetByIdCar(1);
            Console.WriteLine("id :{0},marka :{1}, renk :{2}, açıklama :{3}, model :{4}, günlük :{5}", getCar.Id,
                getCar.BrandId, getCar.ColorId, getCar.Description, getCar.ModelYear, getCar.DailyPrice);
        }

        private static void DeleteCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.DeleteCar(new Car
            {
                Id = 1003
            });
        }

        private static void UpdateCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.UpdateCar(new Car
            {
                Id = 1,
                BrandId = 3,
                ColorId = 3,
                DailyPrice = 300,
                Description = "LPG",
                ModelYear = 2022
            });
        }

        private static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.AddCar(new Car
            {
                BrandId = 4,
                ColorId = 5,
                DailyPrice = 175,
                Description = "Benzinli",
                ModelYear = 2016
            });
        }

        private static void GetAllCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("id :{0},marka :{1}, renk :{2}, açıklama :{3}, model :{4}, günlük :{5}",car.Id,car.BrandId,car.ColorId,car.Description,car.ModelYear,car.DailyPrice);
            }
        }
    }
}
