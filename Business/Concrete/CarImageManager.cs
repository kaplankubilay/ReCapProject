using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheAspect]
        public IDataResult<IList<CarImage>> GetAllCarImages()
        {
            try
            {
                IList<CarImage> getListCarImages = _carImageDal.GetAll();

                return new SuccessDataResult<IList<CarImage>>(getListCarImages);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [CacheAspect]
        public IDataResult<CarImage> GetByCarId(int carId)
        {
            try
            {
                CarImage car = _carImageDal.Get(x => x.CarId == carId);

                CarImage imageResult = CarImageNullControl(car);

                return new SuccessDataResult<CarImage>(imageResult);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult AddCarImage(IFormFile file, CarImage carImage)
        {
            try
            {
                IResult result = BusinessMotor.Run(ImageCountControl(carImage));

                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult UpdateCarImage(IFormFile file,CarImage carImage)
        {
            try
            {
                IResult result = BusinessMotor.Run(ImageCountControl(carImage));

                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
                _carImageDal.Update(carImage);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult DeleteCarImage(CarImage carImage)
        {
            try
            {
                CarImage getImage = _carImageDal.Get(x => x.Id == carImage.Id);
                FileHelper.Delete(getImage.ImagePath);
                _carImageDal.Delete(getImage);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        private IResult ImageCountControl(CarImage carImage)
        {
            int count = _carImageDal.GetAll(x => x.CarId == carImage.CarId).Count;
            if (count > 5)
            {
                return new ErrorResult(Messages.Error);
            }
            return new SuccessResult();
        }

        private CarImage CarImageNullControl(CarImage carImage)
        {
            try
            {
                if (carImage.ImagePath == null)
                {
                    carImage = new CarImage
                    {
                        Id = carImage.Id,
                        CarId = carImage.CarId,
                        ImagePath = Environment.CurrentDirectory + @"\Images\DefaultImage.png",
                        Date = DateTime.Now
                    };
                }
                
                return carImage;
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }
    }
}
