using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<IList<Rental>> GetAllRentals();
        IDataResult<Rental> GetByRentalId(int rentalId);
        IResult AddRental(Rental rental);
        IResult UpdateRental(Rental rental);
        IResult DeleteRental(Rental rental);

        /// <summary>
        /// Rental detayı getirir.
        /// </summary>
        /// <returns></returns>
        IDataResult<IList<RentalDetailDto>> GetRentalDetailDto();
    }
}
