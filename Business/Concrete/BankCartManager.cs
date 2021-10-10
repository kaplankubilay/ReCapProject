using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BankCartManager: IBankCartService
    {
        private IBankCartDal _bankCartDal;

        public BankCartManager(IBankCartDal bankCartDal)
        {
            _bankCartDal = bankCartDal;
        }

        public IDataResult<IList<BankCart>> GetCartByUserId(int userId)
        {
            try
            {
                IList<BankCart> cartFind = _bankCartDal.GetAll(x => x.UserId == userId);
                return new SuccessDataResult<IList<BankCart>>(cartFind);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddBankCart(BankCart bankCart)
        {
            try
            {
                var result = BusinessMotor.Run(AlreadyExistCartControl(bankCart));
                if (result != null)
                {
                    return result;
                }
                _bankCartDal.Add(bankCart);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }
        
        public IResult DeleteBankCart(BankCart bankCart)
        {
            try
            {
                BankCart deleteCart = _bankCartDal.Get(x => x.Id == bankCart.Id);
                _bankCartDal.Delete(deleteCart);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        private IResult AlreadyExistCartControl(BankCart bankCart)
        {
            IList<BankCart> carts = _bankCartDal.GetAll();
            foreach (BankCart cart in carts)
            {
                if (cart.CartNo == bankCart.CartNo)
                {
                    return new ErrorResult(Messages.AlreadyCartExist);
                }
            }

            return new SuccessResult();
        }
    }
}
