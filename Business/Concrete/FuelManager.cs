using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FuelManager:IFuelService
    {
        private IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public IList<Fuel> GetAAllFuels()
        {
            return _fuelDal.GetAll();
        }

        public Fuel GetByIdFuel(int id)
        {
            try
            {
                return _fuelDal.Get(f => f.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("GetBtIdFuel calismadi.",exception);
            }
        }

        public void AddFuel(Fuel fuel)
        {
            try
            {
                _fuelDal.Add(fuel);
            }
            catch (Exception exception)
            {
                throw new Exception("AddFuel calismadi.", exception);
            }
        }

        public void UpdateFuel(Fuel fuel)
        {
            try
            {
                _fuelDal.Update(fuel);
            }
            catch (Exception exception)
            {
                throw new Exception("UpdateFuel calismadi.", exception);
            }
        }

        public void DeleteFuel(Fuel fuel)
        {
            try
            {
                Fuel deleteFuel = _fuelDal.Get(f => f.Id == fuel.Id);
                _fuelDal.Delete(deleteFuel);
            }
            catch (Exception exception)
            {
                throw new Exception("DeleteFuel calismadi.", exception);
            }
        }
    }
}
