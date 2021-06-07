using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<IList<Car>> GetAll()
        {
            return new SuccessDataResult<IList<Car>>(_carDal.GetAll());
        }

        public IDataResult<IList<Car>> GetCarsByBrandId(int id)
        {
            IList<Car> getCars = _carDal.GetAll(b => b.BrandId == id).ToList();
            return new SuccessDataResult<IList<Car>>(getCars);
        }

        public IDataResult<IList<Car>> GetCarsByColorId(int id)
        {
            IList<Car> getCars= _carDal.GetAll(c => c.ColorId == id).ToList();
            return new SuccessDataResult<IList<Car>>(getCars);
        }

        public IResult AddCar(Car car)
        {
            try
            {
                if (AddCarConditional(car))
                {
                    _carDal.Add(car);
                }
                return new Result(true,Messages.CarAdded);
            }
            catch (Exception exception)
            {
                throw new Exception("Arac eklenemedi",exception);
            }
        }

        public IDataResult<Car> GetByIdCar(int id)
        {
            try
            {
                Car getCar = _carDal.Get(c => c.Id == id);
                return new DataResult<Car>(getCar,true);
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

        public IResult UpdateCar(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new Result(true,Messages.CarUpdated);
            }
            catch (Exception exception)
            {
                throw new Exception("Arac guncelleme yapilamadi.",exception);
            }
        }

        public IResult DeleteCar(Car car)
        {
            try
            {
                Car deleteCar = _carDal.Get(c => c.Id == car.Id);
                _carDal.Delete(deleteCar);
                return new Result(true,Messages.CarDeleted);
            }
            catch (Exception exception)
            {
                throw new Exception("Arac silinemedi..",exception);
            }
        }

        public IDataResult<IList<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetCarDetailDtos()); 
        }
    }
}
