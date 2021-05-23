using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private IInMemoryCarDal _carDal;

        public CarManager(IInMemoryCarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            return (List<Car>) _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }
    }
}
