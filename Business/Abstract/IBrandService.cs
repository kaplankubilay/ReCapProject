using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<IList<Brand>> GetAllBrands();
        IDataResult<Brand> GetByIdBrand (int id);
        IResult UpdateBrand(Brand brand);
        IResult AddBrand(Brand brand);
        IResult DeleteBrand(Brand brand);
    }
}
