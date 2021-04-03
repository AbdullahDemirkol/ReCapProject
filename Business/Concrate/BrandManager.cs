using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2 )
            {
                return new ErrorResult(Messages.BrandErrorAdded);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandSuccessAdded);
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandSuccessDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result==null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandErrorListed);
            }
            return new SuccessDataResult<List<Brand>>(result,Messages.BrandSuccessListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(p => p.BrandId == brandId);
            if (result==null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandErrorGetById);
            }
            return new SuccessDataResult<Brand>(result, Messages.BrandSuccessGetById);
        }

        public IResult Update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandErrorUpdated);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandSuccessUpdated);
        }
    }
}
