using Business.Abstract;
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
        public string GetByBrand(Car car)
        {
            /*return _brandDal.GetByBrand(car);*/
            return _brandDal.Get(p => p.BrandId == car.BrandId).BrandName;
        }
    }
}
