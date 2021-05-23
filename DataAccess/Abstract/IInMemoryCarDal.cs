using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInMemoryCarDal
    {
        /// <summary>
        /// getAll car list
        /// </summary>
        /// <returns></returns>
        IList<Car> GetAll();

        /// <summary>
        /// GetById car object
        /// </summary>
        /// <param name="carId"></param>
        Car GetById(int carId);

        /// <summary>
        /// add a new car
        /// </summary>
        /// <param name="car"></param>
        void Add(Car car);

        /// <summary>
        /// update a car
        /// </summary>
        /// <param name="car"></param>
        void Update(Car car);

        /// <summary>
        /// delete a car
        /// </summary>
        /// <param name="car"></param>
        void Delete(Car car);
    }
}
