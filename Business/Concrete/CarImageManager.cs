using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

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
                IResult result = BusinessMotor.Run(ImageCountControl(carImage));

                CarImage isNullImage = CarImageNullControl(carImage);

                if (result != null)
                {
                    return result;
                }

                if (isNullImage==null)
                {
                    carImage.ImagePath = isNullImage.ImagePath;
                }

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

        private IResult ImageCountControl(CarImage carImage)
        {
            int count = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Count;
            if (count>5)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }

        private CarImage CarImageNullControl(CarImage carImage)
        {
            try
            {
                bool control = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Any();
                if (!control)
                {
                    CarImage image = new CarImage
                    {
                        ImagePath = carImage.ImagePath
                    };
                    return image;
                }

                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }
    }
}
