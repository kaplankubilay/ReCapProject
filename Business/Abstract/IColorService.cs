using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<IList<Color>> GetAllColors();
        IDataResult<Color> GetByIdColor(int id);
        IResult UpdateColor(Color color);
        IResult AddColor(Color color);
        IResult DeleteColor(Color color);
    }
}
