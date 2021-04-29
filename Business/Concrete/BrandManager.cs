using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        [SecuredOperation("brand.add,moderator")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandSuccessAdded);
        }


        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandSuccessDeleted);
        }


        [SecuredOperation("brand.list,user")]
        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result==null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandErrorListed);
            }
            return new SuccessDataResult<List<Brand>>(result,Messages.BrandSuccessListed);
        }


        [SecuredOperation("brand.list,moderator")]
        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(p => p.BrandId == brandId);
            if (result==null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandErrorGetById);
            }
            return new SuccessDataResult<Brand>(result, Messages.BrandSuccessGetById);
        }


        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandSuccessUpdated);
        }
    }
}
