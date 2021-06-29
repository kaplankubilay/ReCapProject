using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<IList<Car>> GetAll();
        IDataResult<IList<Car>> GetCarsByBrandId(int id);
        IDataResult<IList<Car>> GetCarsByColorId(int id);
        IResult AddCar(Car car);
        IDataResult<Car> GetByIdCar(int id);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);

        /// <summary>
        /// Car detail dto nesnesi.
        /// </summary>
        /// <returns></returns>
        IDataResult<IList<CarDetailDto>> GetCarDetailDtos();
    }
}
