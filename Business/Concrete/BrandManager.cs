using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IList<Brand> GetAllBrands()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByIdBrand(int id)
        {
            try
            {
                return _brandDal.Get(b => b.Id == id);
            }
            catch (Exception exception)
            {
                throw new Exception("GetByIdBrand calismadi.",exception);
            }
        }

        public void UpdateBrand(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
            }
            catch (Exception exception)
            {
                throw new Exception("UpdateBrand calismadi.",exception);
            }
        }

        public void AddBrand(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
            }
            catch (Exception exception)
            {
                throw new Exception("AddBrand calismadi.", exception);
            }
        }

        public void DeleteBrand(Brand brand)
        {
            try
            {
                Brand deleteBrand = _brandDal.Get(b => b.Id == brand.Id);
                _brandDal.Delete(deleteBrand);
            }
            catch (Exception exception)
            {
                throw new Exception("DeleteBrand calismadi.", exception);
            }
        }
    }
}
