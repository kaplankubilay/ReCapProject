using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        IList<Car> GetAll();
        IList<Car> GetCarsByBrandId(int id);
        IList<Car> GetCarsByColorId(int id);
        void AddCar(Car car);
        bool AddCarConditional(Car car);
    }
}
