using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }


        [SecuredOperation("brand.add,moderator")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerSuccessAdded);
        }


        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerSuccessDeleted);
        }


        [SecuredOperation("brand.list,moderator")]
        public IDataResult<List<CustomerDetailDto>> GetAll()
        {
            var result = _customerDal.CustomerDetailDto();
            if (result==null)
            {
                return new ErrorDataResult<List<CustomerDetailDto>>(Messages.CustomerDetailsErrorListed);
            }
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.CustomerDetailDto(), Messages.CustomerDetailsSuccessListed);
        }


        [SecuredOperation("brand.list,moderator")]
        public IDataResult<Customer> GetById(int userId)
        {
            var result = _customerDal.Get(p => p.UserId == userId);
            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerErrorGetByUserId);
            }
            return new SuccessDataResult<Customer>(result, Messages.CustomerSuccessGetByUserId);
        }


        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerSuccessUpdated);
        }
    }
}
