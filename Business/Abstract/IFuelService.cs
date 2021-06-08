using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFuelService
    {
        IDataResult<IList<Fuel>> GetAAllFuels();
        IDataResult<Fuel> GetByIdFuel(int Id);
        IResult AddFuel(Fuel fuel);
        IResult UpdateFuel(Fuel fuel);
        IResult DeleteFuel(Fuel fuel);
    }
}
