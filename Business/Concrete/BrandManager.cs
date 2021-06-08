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
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public IDataResult<IList<Brand>> GetAllBrands()
        {
            IList<Brand> getListBrand = _brandDal.GetAll();
            return new SuccessDataResult<IList<Brand>>(getListBrand); 
        }

        public IDataResult<Brand> GetByIdBrand(int id)
        {
            try
            {
                Brand getBrand = _brandDal.Get(b => b.Id == id);
                return new SuccessDataResult<Brand>(getBrand);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error,exception);
            }
        }

        public IResult UpdateBrand(Brand brand)
        {
            try
            {
                if (brand.Name.Length < 2)
                {
                    return new ErrorResult(Messages.FaultEntry);
                }

                _brandDal.Update(brand);
                return new Result(true,Messages.BrandUpdate);

            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult AddBrand(Brand brand)
        {
            try
            {
                _brandDal.Add(brand);
                return new Result(true,Messages.BrandAdded); 
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }

        public IResult DeleteBrand(Brand brand)
        {
            try
            {
                Brand deleteBrand = _brandDal.Get(b => b.Id == brand.Id);
                _brandDal.Delete(deleteBrand);
                return new Result(true,Messages.BrandDeleted);
            }
            catch (Exception exception)
            {
                throw new Exception(Messages.Error, exception);
            }
        }
    }
}
