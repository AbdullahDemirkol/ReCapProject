using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RecapContext context=new RecapContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             select new CarDetailDto
                             {
                                 Id=car.Id,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 CarImages = (from image in context.CarImages where image.CarId == car.Id select image.ImagePath).ToList(),
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
