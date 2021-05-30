using System;
using System.Collections.Generic;
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
            //GetAllFuels();
            //GetByIdFuel();
            //AddFuel();
            //UpdateFuel();
            //DeleteFuel();

            //GetAllColors();
            //GetByIdColor();
            //AddColor();
            //UpdateColor();
            //DeleteColor();

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

        private static void GetByIdFuel()
        {
            FuelManager fuelManager = new FuelManager(new EfFuelDal());
            Fuel getFuel = fuelManager.GetByIdFuel(2);
            Console.WriteLine("id : {0}, Name : {1}", getFuel.Id, getFuel.Name);
        }

        private static void DeleteFuel()
        {
            FuelManager fuelManager = new FuelManager(new EfFuelDal());
            fuelManager.DeleteFuel(new Fuel
            {
                Id = 6
            });
        }

        private static void UpdateFuel()
        {
            FuelManager fuelManager = new FuelManager(new EfFuelDal());
            fuelManager.UpdateFuel(new Fuel
            {
                Id = 6,
                Name = "Dzl"
            });
        }

        private static void AddFuel()
        {
            FuelManager fuelManager = new FuelManager(new EfFuelDal());
            fuelManager.AddFuel(new Fuel
            {
                Name = "Benz"
            });
        }

        private static void GetAllFuels()
        {
            FuelManager fuelManager = new FuelManager(new EfFuelDal());
            IList<Fuel> fuelList = fuelManager.GetAAllFuels();
            foreach (var fuel in fuelList)
            {
                Console.WriteLine("id : {0}, Name : {1}", fuel.Id, fuel.Name);
            }
        }

        private static void DeleteColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.DeleteColor(new Color
            {
                Id = 1002
            });
        }

        private static void UpdateColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.UpdateColor(new Color
            {
                Id = 1002,
                Name = "Lila"
            });
        }

        private static void AddColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.AddColor(new Color
            {
                Name = "Mor"
            });
        }

        private static void GetByIdColor()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = colorManager.GetByIdColor(1);
            Console.WriteLine("id : {0}, Name : {1}", color.Id, color.Name);
        }

        private static void GetAllColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            IList<Color> getColors = colorManager.GetAllColors();
            foreach (var color in getColors)
            {
                Console.WriteLine("id : {0}, Name : {1}", color.Id, color.Name);
            }
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
