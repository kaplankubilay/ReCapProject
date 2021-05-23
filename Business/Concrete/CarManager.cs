using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IList<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public IList<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(b => b.BrandId == id).ToList();
        }

        public IList<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id).ToList();
        }

        public void AddCar(Car car)
        {
            try
            {
                if (AddCarConditional(car))
                {
                    _carDal.Add(car);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool AddCarConditional(Car car)
        {
            if (car.DailyPrice > 0 && car.Description.Length >= 2)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Günlük ücret 0 dan büyük ve Açıklama en az 2 karakter olmalıdır.");
                return false;
            }
        }
    }
}
