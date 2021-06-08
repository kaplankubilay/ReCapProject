using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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
    }
}
