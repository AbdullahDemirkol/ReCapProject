using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.CompanyName.Length<2)
            {
                return new ErrorResult(Messages.CustomerErrorAdded);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerSuccessAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerSuccessDeleted);
        }

        public IDataResult<List<CustomerDetailDto>> GetAll()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.CustomerDetailDto(), Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int userId)
        {
            var result = _customerDal.Get(p => p.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerErrorGetByUserId);
            }
            return new SuccessDataResult<Customer>(result, Messages.CustomerSuccessGetByUserId);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerSuccessUpdated);
        }
    }
}
