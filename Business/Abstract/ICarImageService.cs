using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<IList<CarImage>> GetAllCarImages();
        IDataResult<CarImage> GetByCarId(int carId);
        IResult AddCarImage(CarImage carImage);
        IResult UpdateCarImage(CarImage carImage);
        IResult DeleteCarImage(CarImage carImage);
    }
}
