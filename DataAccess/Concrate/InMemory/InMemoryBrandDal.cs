using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Audi"},
                new Brand{BrandId=2,BrandName="BMW"},
                new Brand{BrandId=3,BrandName="Ford"},
                new Brand{BrandId=4,BrandName="Opel"},
                new Brand{BrandId=5,BrandName="Volvo"}
            };
        }

        public void Add(Brand Entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand Entity)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public string GetByBrand(Car car)
        {
            return _brands.FirstOrDefault(p=>p.BrandId==car.BrandId).BrandName;
        }

        public void Update(Brand Entity)
        {
            throw new NotImplementedException();
        }
    }
}
