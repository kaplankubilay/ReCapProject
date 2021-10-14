using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IDataResult<IList<Payment>> GetAllPayments();
        IResult AddPayment(Payment payment);
        IResult DeletePayment(Payment payment);
    }
}