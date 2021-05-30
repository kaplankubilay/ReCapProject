using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

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
            catch (Exception exception)
            {
                throw new Exception("Arac eklenemedi",exception);
            }
        }

        public Car GetByIdCar(int id)
        {
            try
            {
                return _carDal.Get(c => c.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("Id bazli arac getirilemedi.",exception);
            }
        }

        public bool AddCarConditional(Car car)
        {
            try
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
            catch (Exception exception)
            {
                throw  new Exception("Kontrol metodunda hata var.",exception);
            }
        }

        public void UpdateCar(Car car)
        {
            try
            {
                _carDal.Update(car);
            }
            catch (Exception exception)
            {
                throw new Exception("Arac guncelleme yapilamadi.",exception);
            }
        }

        public void DeleteCar(Car car)
        {
            try
            {
                Car deleteCar = _carDal.Get(c => c.Id == car.Id);
                _carDal.Delete(deleteCar);
            }
            catch (Exception exception)
            {
                throw new Exception("Arac silinemedi..",exception);
            }
        }

        public IList<CarDetailDto> GetCarDetailDtos()
        {
            return _carDal.GetCarDetailDtos();
        }
    }
}
