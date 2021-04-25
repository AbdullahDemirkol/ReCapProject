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

namespace DataAccess.Concrate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetailsDto()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from ren in context.Rentals
                             join car in context.Cars
                             on ren.CarId equals car.Id
                             join cus in context.Customers
                             on ren.CustomerId equals cus.Id
                             join user in context.Users
                             on cus.UserId equals user.Id
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             join bra in context.Brands
                             on car.BrandId equals bra.BrandId

                             select new RentalDetailDto
                             {
                                 CarDescription = car.Description,
                                 ColorName = col.ColorName,
                                 BrandName = bra.BrandName,
                                 CompanyName = cus.CompanyName,
                                 CustomerFirstName = user.FirstName,
                                 CustomerLastName = user.LastName,
                                 DailyPrice = car.DailyPrice,
                                 RentDate = ren.RentDate,
                                 ReturnDate = (DateTime)ren.ReturnDate,
                             };

                return result.ToList();
            }
        }
    }
}
