using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business.BusinessTools;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<IList<Color>> GetAllColors()
        {
            return new SuccessDataResult<IList<Color>>(_colorDal.GetAll()); 
        }

        public IDataResult<Color> GetByIdColor(int id)
        {
            try
            {
                Color getColor = _colorDal.Get(c => c.Id == id);
                return new SuccessDataResult<Color>(getColor);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult UpdateColor(Color color)
        {
            try
            {
                _colorDal.Update(color);
                return new Result(true,Messages.ColorUpdate); 
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddColor(Color color)
        {
            try
            {
                var result = BusinessMotor.Run(AlreadyExistColorControl(color), ColorNameLengthControl(color));
                if (result != null)
                {
                    return result;
                }
                _colorDal.Add(color);
                return new Result(true,Messages.ColorAdded);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteColor(Color color)
        {
            try
            {
                Color deleteColor = _colorDal.Get(c => c.Id == color.Id);
                _colorDal.Delete(deleteColor);
                return new Result(true,Messages.ColorDeleted);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        private IResult ColorNameLengthControl(Color color)
        {
            int lenght = color.Name.Length;
            if (lenght<2)
            {
                return new ErrorResult(Messages.NameLenghtControl);
            }
            return new SuccessResult();
        }

        private IResult AlreadyExistColorControl(Color color)
        {
            bool result = _colorDal.GetAll(x => x.Name == color.Name).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyAxistPropertyName);
            }
            return new SuccessResult();
        } 
    }
}
