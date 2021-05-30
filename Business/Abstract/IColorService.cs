using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IList<Color> GetAllColors();
        Color GetByIdColor(int id);
        void UpdateColor(Color color);
        void AddColor(Color color);
        void DeleteColor(Color color);
    }
}
