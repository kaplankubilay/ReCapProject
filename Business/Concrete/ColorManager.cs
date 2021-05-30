using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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

        public IList<Color> GetAllColors()
        {
            return _colorDal.GetAll();
        }

        public Color GetByIdColor(int id)
        {
            try
            {
                return _colorDal.Get(c => c.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("GetByIdColor calismadi.",exception);
            }
        }

        public void UpdateColor(Color color)
        {
            try
            {
                _colorDal.Update(color);
            }
            catch (Exception exception)
            {
                throw new Exception("UpdateColor calismadi.", exception);
            }
        }

        public void AddColor(Color color)
        {
            try
            {
                _colorDal.Add(color);
            }
            catch (Exception exception)
            {
                throw new Exception("AddColor calismadi.", exception);
            }
        }

        public void DeleteColor(Color color)
        {
            try
            {
                Color deleteColor = _colorDal.Get(c => c.Id == color.Id);
                _colorDal.Delete(deleteColor);
            }
            catch (Exception exception)
            {
                throw new Exception("DeleteColor calismadi.", exception);
            }
        }
    }
}
