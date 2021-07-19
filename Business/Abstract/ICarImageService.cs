using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<IList<CarImage>> GetAllCarImages();
        IDataResult<CarImage> GetByCarId(int carId);
        IResult AddCarImage(IFormFile file,CarImage carImage);
        IResult UpdateCarImage(IFormFile file,CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
    }
}
