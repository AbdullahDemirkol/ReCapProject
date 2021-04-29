using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingCornerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.SuccesAddCar);
        }


        [SecuredOperation("car.list,user")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            var result = _carDal.GetAll();
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarsErrorListed);
            }
            return new SuccessDataResult<List<Car>>(result,Messages.CarsSuccessListed);
        }


        [SecuredOperation("car.list,user")]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            var result = _carDal.GetCarDetails();
            if (result==null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarDetailsErrorListed);
            }
            return new SuccessDataResult<List<CarDetailDto>>(result,Messages.CarDetailsSuccessListed);
        }


        [SecuredOperation("car.list,user")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandid)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            var result = _carDal.GetAll(p => p.BrandId == brandid);
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarBrandListedNull);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.SelectedBrandListed);
        }


        [SecuredOperation("car.list,user")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorid)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            var result = _carDal.GetAll(p => p.BrandId == colorid);
            if (result==null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarColorListedNull);
            }
            return new SuccessDataResult<List<Car>>(result, Messages.SelectedColorListed);
        }


        [SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessRemoveCar);
        }


        [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccesUpdateCar);
        }
    }
}
