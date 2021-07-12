using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
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

        public IDataResult<IList<Fuel>> GetAAllFuels()
        {
            return new SuccessDataResult<IList<Fuel>>(_fuelDal.GetAll());
        }

        public IDataResult<Fuel> GetByIdFuel(int id)
        {
            try
            {
                Fuel getFuel = _fuelDal.Get(f => f.Id == id);
                return new SuccessDataResult<Fuel>(getFuel);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddFuel(Fuel fuel)
        {
            try
            {
                var result = BusinessMotor.Run(FuelNameLenghtControl(fuel), AlreadyExistFuelName(fuel));
                if (result != null)
                {
                    return result;
                }

                _fuelDal.Add(fuel);
                return new Result(true,Messages.FuelAdded);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult UpdateFuel(Fuel fuel)
        {
            try
            {
                _fuelDal.Update(fuel);
                return new Result(true,Messages.FuelUpdated);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteFuel(Fuel fuel)
        {
            try
            {
                Fuel deleteFuel = _fuelDal.Get(f => f.Id == fuel.Id);
                _fuelDal.Delete(deleteFuel);
                return new Result(true,Messages.FuelDeleted);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        private IResult AlreadyExistFuelName(Fuel fuel)
        {
            bool result = _fuelDal.GetAll(x => x.Name == fuel.Name).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyAxistPropertyName);
            }
            return new SuccessResult();
        }

        private IResult FuelNameLenghtControl(Fuel fuel)
        {
            int result = fuel.Name.Length;
            if (result < 2)
            {
                return new ErrorResult(Messages.NameLenghtControl);
            }
            return new SuccessResult();
        }
    }
}
