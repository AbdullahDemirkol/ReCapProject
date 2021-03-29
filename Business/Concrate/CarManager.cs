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
            else
            {
                if (car.DailyPrice > 0 && car.Description.Length > 2)
                {
                    _carDal.Add(car);
                    return new SuccessResult(Messages.SuccesAddCar);
                }
                else
                {
                    return new ErrorResult(Messages.ErrorAddCar);
                }
            }
        }
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsDto()
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),Messages.CarsDetailListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandid)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.BrandId==brandid),Messages.SelectedBrandListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorid)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == colorid),Messages.SelectedColorListed);
        }

        public IResult Remove(Car car)
        {
            if (DateTime.Now.Hour == 24)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            else
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.SuccessRemoveCar);
            }
        }
    }
}
