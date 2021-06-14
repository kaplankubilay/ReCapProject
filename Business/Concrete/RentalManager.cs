using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<IList<Rental>> GetAllRentals()
        {
            try
            {
                IList<Rental> rentals = _rentalDal.GetAll();
                return new SuccessDataResult<IList<Rental>>(rentals);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            try
            {
                Rental getRental = _rentalDal.Get(x => x.Id == rentalId);
                return new SuccessDataResult<Rental>(getRental);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddRental(Rental rental)
        {
            try
            {
                if (AddRentalControl(rental))
                {
                    _rentalDal.Add(rental);
                    return new Result(true, Messages.Success);
                }
                return new ErrorResult(Messages.RentalControlMessage);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult UpdateRental(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteRental(Rental rental)
        {
            try
            {
                Rental deleteRental = _rentalDal.Get(x => x.Id == rental.Id);
                _rentalDal.Delete(deleteRental);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public bool AddRentalControl(Rental rental)
        {
            IList<Rental> rentals = _rentalDal.GetAll();

            foreach (var rent in rentals)
            {
                if (rent.CarId == rental.CarId && rent.ReturnDate == null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
