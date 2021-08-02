using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect]
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

        [CacheAspect]
        public IDataResult<IList<RentalDetailDto>> GetRentalDetailDto()
        {
            try
            {
                IList<RentalDetailDto> getRentalDetails = _rentalDal.GetRentalDetailDtos();
                return new SuccessDataResult<IList<RentalDetailDto>>(getRentalDetails);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult AddRental(Rental rental)
        {
            try
            {
                var result = BusinessMotor.Run(AddRentalControl(rental));
                if (result != null)
                {
                    return result;
                }

                _rentalDal.Add(rental);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
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

        [CacheRemoveAspect("IRentalService.Get")]
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

        public IResult AddRentalControl(Rental rental)
        {
            IList<Rental> rentals = _rentalDal.GetAll();

            foreach (var rent in rentals)
            {
                if (rent.CarId == rental.CarId && rent.ReturnDate == null)
                {
                    return new ErrorResult(Messages.CarNotReturnYet);
                }
            }

            return new SuccessResult();
        }
    }
}
