using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:IInMemoryCarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId = 1,ColorId = 1,DailyPrice = 10,Description = "Az yakar çok kaçar",Id = 1,ModelYear = 2020},
                new Car{BrandId = 2,ColorId = 2,DailyPrice = 20,Description = "Az yakar",Id = 2,ModelYear = 2021},
                new Car{BrandId = 3,ColorId = 2,DailyPrice = 30,Description = "Çok kaçar",Id = 3,ModelYear = 2019}
            };
        }

        public IList<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.FirstOrDefault(c => c.Id == carId);
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(Car car)
        {
            Car carUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carUpdate.BrandId = car.BrandId;
            carUpdate.Description = car.Description;
            carUpdate.DailyPrice = car.DailyPrice;
            carUpdate.ModelYear = car.ModelYear;
            carUpdate.ColorId = car.ColorId;
        }

        public void Delete(Car car)
        {
            Car carDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carDelete);
        }
    }
}
