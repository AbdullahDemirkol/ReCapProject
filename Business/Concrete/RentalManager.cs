using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }


        [SecuredOperation("rental.add,moderator")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (result.Any())
            {
                return new ErrorResult(Messages.RentalNullReturnDate);
            }
            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalSuccessAdded);
            }
        }


        [SecuredOperation("rental.delete,admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalSuccessDeleted);
        }

        
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalErrorListed);
            }
            return new SuccessDataResult<List<Rental>>(result, Messages.RentalSuccessListed);
        }


        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            var result = _rentalDal.GetRentalDetailsDto();
            if (result==null)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.RentalDetailErrorListed);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(result,Messages.RentalDetailSuccessListed);
        }


        [SecuredOperation("rental.update,admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalSuccessUpdated);

        }

    }
}
