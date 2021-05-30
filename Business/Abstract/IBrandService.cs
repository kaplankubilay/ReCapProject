using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IList<Brand> GetAllBrands();
        Brand GetByIdBrand (int id);
        void UpdateBrand(Brand brand);
        void AddBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
