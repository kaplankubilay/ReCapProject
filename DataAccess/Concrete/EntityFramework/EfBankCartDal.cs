using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBankCartDal : EfEntityRepositoryBase<BankCart, CarRentalContext>, IBankCartDal
    {
        
    }
}