using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IFuelService
    {
        IList<Fuel> GetAAllFuels();
        Fuel GetByIdFuel(int Id);
        void AddFuel(Fuel fuel);
        void UpdateFuel(Fuel fuel);
        void DeleteFuel(Fuel fuel);
    }
}
