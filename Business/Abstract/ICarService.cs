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
        bool AddCarConditional(Car car);
        void AddCar(Car car);
        Car GetByIdCar(int id);
        void UpdateCar(Car car);
        void DeleteCar(Car car);
    }
}
