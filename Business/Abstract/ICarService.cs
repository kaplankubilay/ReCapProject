using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        /// <summary>
        /// getAll car list
        /// </summary>
        /// <returns></returns>
        List<Car> GetAll();

        /// <summary>
        /// GetById car object
        /// </summary>
        /// <param name="carId"></param>
        Car GetById(int carId);
    }
}
