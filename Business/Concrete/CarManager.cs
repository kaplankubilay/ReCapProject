using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.ValidationTool;
using Core.Utilities.Business.BusinessTools;
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

        [SecuredOperation("Car.add")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            try
            {
                IResult result = BusinessMotor.Run(DescriptionLenghtMinConrtrol(car));
                if (result != null)
                {
                    return result;
                }

                ValidationTool.Validate(new CarValidator(),car);
                
                _carDal.Add(car);
                return new Result(true,Messages.CarAdded);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
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
                throw new Exception(Messages.Error, exception);
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
                throw new Exception(Messages.Error, exception);
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
                throw new Exception(Messages.Error, exception);
            }
        }

        public IDataResult<IList<CarDetailDto>> GetCarDetailDtos()
        {
            return new SuccessDataResult<IList<CarDetailDto>>(_carDal.GetCarDetailDtos()); 
        }

        private IResult DescriptionLenghtMinConrtrol(Car car)
        {
            int result = car.Description.Length;
            if (result<1)
            {
                return new ErrorResult(Messages.LenghtMinControl);
            }

            return new SuccessResult();
        }
        
    }
}
