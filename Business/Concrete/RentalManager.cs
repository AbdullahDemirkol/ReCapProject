using Business.Abstract;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalSuccessAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalSuccessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Rental>>(Messages.RentalErrorListed);
            }
            return new SuccessDataResult<List<Rental>>(result, Messages.RentalSuccessListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsDto()
        {
            var result = _rentalDal.GetRentalDetailsDto();
            if (result==null)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.RentalDetailErrorListed);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(result,Messages.RentalDetailSuccessListed);
        }
        
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalSuccessUpdated);

        }

    }
}
