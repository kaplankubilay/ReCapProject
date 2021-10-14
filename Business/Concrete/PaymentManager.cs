using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IDataResult<IList<Payment>> GetAllPayments()
        {
            try
            {
                IList<Payment> payments = _paymentDal.GetAll();
                return new SuccessDataResult<IList<Payment>>(payments);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        public IResult AddPayment(Payment payment)
        {
            try
            {
                _paymentDal.Add(payment);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        public IResult DeletePayment(Payment payment)
        {
            try
            {
                Payment findPayment = _paymentDal.Get(x => x.Id == payment.Id);
                _paymentDal.Delete(findPayment);
                return new Result(true,Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }
    }
}