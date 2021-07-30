using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<IList<User>> GetAllUsers()
        {
            return new SuccessDataResult<IList<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByIdUser(int userId)
        {
            try
            {
                User getUser = _userDal.Get(x => x.Id == userId);
                return new SuccessDataResult<User>(getUser);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        public IResult AddUser(User user)
        {
            try
            {
                var result = BusinessMotor.Run(AlreadyExistName(user), NameLenghtControl(user));
                if (result != null)
                {
                    return result;
                }
                
                _userDal.Add(user);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult UpdateUser(User user)
        {
            try
            {
                _userDal.Update(user);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteUser(User user)
        {
            try
            {
                User deletedUser = _userDal.Get(u => u.Id == user.Id);
                _userDal.Delete(deletedUser);
                return new Result(true, Messages.Success);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IDataResult<IList<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<IList<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<User> GetByMail(string email)
        {
            try
            {
                User getUser = _userDal.Get(x => x.Email == email);
                if (getUser != null)
                { 
                    return new SuccessDataResult<User>(getUser);
                }

                return null;
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        private IResult NameLenghtControl(User user)
        {
            var userName = user.FirstName.Length;
            var userLastname = user.LastName.Length;
            var email = user.Email.Length;
            if (userName <2 || userLastname<2 ||email<2)
            {
                return new ErrorResult(Messages.NameLenghtControl);
            }

            return new SuccessResult();
        }

        private IResult AlreadyExistName(User user)
        {
            bool result = _userDal.GetAll(x => x.LastName == user.LastName && x.FirstName == user.FirstName && x.Email == user.Email).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyAxistPropertyName);
            }
            return new SuccessResult();
        }
    }
}
