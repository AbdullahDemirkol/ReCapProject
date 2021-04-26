using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RecapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> CustomerDetailDto()
        {
            using (RecapContext context=new RecapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new CustomerDetailDto
                             {
                                 UserFirstName = u.FirstName,
                                 UserLastName = u.LastName,
                                 UserEmail = u.Email,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
