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
        IResult AddCar(Car car);
        IDataResult<Car> GetByIdCar(int id);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);

        /// <summary>
        /// Car detail dto nesnesi.
        /// </summary>
        /// <returns></returns>
        IDataResult<IList<CarDetailDto>> GetCarDetailDtos();

        /// <summary>
        /// Aynı renge sahip arabaları dönrürür.
        /// </summary>
        /// <returns></returns>
        IDataResult<IList<CarDetailDto>> GetCarsByColorId(int colorId);

        /// <summary>
        /// Aynı markaya sahip aracları getitit.
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        IDataResult<IList<CarDetailDto>> GetCarsByBrandId(int brandId);

        /// <summary>
        /// Trasection örneği oluşturmak için kullanılan metot. 
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        IResult AddTransactionalTest(Car car);
    }
}
