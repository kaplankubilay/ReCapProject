using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<IList<CarImage>> GetAllCarImages()
        {
            try
            {
                IList<CarImage> getListCarImages = _carImageDal.GetAll();
                return new SuccessDataResult<IList<CarImage>>(getListCarImages);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        public IDataResult<CarImage> GetByCarId(int carId)
        {
            try
            {
                CarImage car = _carImageDal.Get(x => x.CarId == carId);
                return new SuccessDataResult<CarImage>(car);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddCarImage(CarImage carImage)
        {
            try
            {
                carImage.Date=DateTime.Now;
                _carImageDal.Add(carImage);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult UpdateCarImage(CarImage carImage)
        {
            try
            {
                _carImageDal.Update(carImage);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteCarImage(CarImage carImage)
        {
            try
            {
                CarImage getImage = _carImageDal.Get(x => x.Id == carImage.Id);
                _carImageDal.Delete(getImage);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }
    }
}
