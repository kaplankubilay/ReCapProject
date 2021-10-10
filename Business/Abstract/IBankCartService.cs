using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBankCartService
    {
        IDataResult<IList<BankCart>> GetCartByUserId(int userId);
        IResult AddBankCart(BankCart bankCart);
        IResult DeleteBankCart(BankCart bankCart);
    }
}