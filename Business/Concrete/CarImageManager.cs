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
        public IDataResult<CarImage> GetImage(int imageId)
        {
            var result = _carImageDal.Get(x => x.Id == imageId);
            return new SuccessDataResult<CarImage>(result);
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
        public IDataResult<IList<CarImage>> GetImagesByCarId(int carId)
        {
            try
            {
                CarImage car = _carImageDal.Get(x => x.CarId == carId);

                IList<CarImage> imageResult = CarImageNullControl(car);

                return new SuccessDataResult<IList<CarImage>>(imageResult);
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
                IResult result = BusinessMotor.Run(ImageCountControl(carImage),CheckFileType(file));

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
                IResult result = BusinessMotor.Run(CheckFileType(file),CheckImagePath(carImage));

                if (result != null)
                {
                    return result;
                }

                carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
                carImage.Date=DateTime.Now;
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
                IResult result = BusinessMotor.Run(CheckImagePath(carImage));

                if (result != null)
                {
                    return result;
                }

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

        private IList<CarImage> CarImageNullControl(CarImage carImage)
        {
            try
            {
                if (carImage.ImagePath == null)
                {
                    carImage = new CarImage
                    {
                        Id = carImage.Id,
                        CarId = carImage.CarId,
                        ImagePath = Environment.CurrentDirectory + @"\wwwroot\images\defaultPhoto.jpg",
                        Date = DateTime.Now
                    };

                    return (IList<CarImage>)carImage;
                }
                else
                {
                    IList<CarImage> carImages = _carImageDal.GetAll(x => x.CarId == carImage.CarId);
                    return carImages;
                }
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        /// <summary>
        /// resim uzantisi kontrol.
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        private IResult CheckFileType(IFormFile formFile)
        {
            string[] types = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };
            string fileType = formFile.FileName.ToString().ToLower();
            foreach (var type in types)
            {
                if (fileType.Contains(type))
                {
                    return new SuccessResult();
                }
            }

            return new ErrorResult(Messages.ImageTypeError);
        }

        /// <summary>
        /// resim adresi ve araba kontrolu yapılır.
        /// </summary>
        /// <param name="carImage"></param>
        /// <returns></returns>
        private IResult CheckImagePath(CarImage carImage)
        {
            var result = _carImageDal.Get(x => x.ImagePath == carImage.ImagePath && carImage.CarId == carImage.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.CheckImagePathOrCar);
            }
            return new SuccessResult();
        }
    }
}
