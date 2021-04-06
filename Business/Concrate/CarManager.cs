using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.SuccesAddCar);
        }
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

        public IResult Remove(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessRemoveCar);
        }
        public IResult Update(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            if (car.DailyPrice <= 0 || car.Description.Length < 2)
            {
                return new ErrorResult(Messages.ErrorUpdateCar);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccesUpdateCar);
        }
    }
}
