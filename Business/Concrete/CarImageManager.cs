using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExcede(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            var image = FileHelper.Add(file);
            if (!image.Success)
            {
                return new ErrorResult(image.Message);
            }
            carImage.ImagePath = image.Message;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageSuccessAdded);
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var Image = _carImageDal.Get(c => c.Id == carImage.Id);
            var result = BusinessRules.Run(CheckIfCarImageLimitExcede(carImage.CarId), CarImageFound(Image));
            if (result != null)
            {
                return result;
            }
            var updatedFile = FileHelper.Update(file, carImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImagedSuccessUpdated);
        }
        public IResult Delete(int id)
        {
            var Image = _carImageDal.Get(c => c.Id == id);
            var result = BusinessRules.Run(CarImageFound(Image));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(Image.ImagePath);
            _carImageDal.Delete(Image);
            return new SuccessResult(Messages.CarImageSuccessDeleted);
        }

        
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            if (result==null)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.CarImageErrorListed);
            }
            return new SuccessDataResult<List<CarImage>>(result, Messages.CarImageSuccessListed);
        }
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId).Data);
        }

        
        private IResult CheckIfCarImageLimitExcede(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }
        private IResult CarImageFound(CarImage carImage)
        {
            if (carImage == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
                if (!result)
                {
                    string path = @"\images\logo.jpg";
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId).ToList());
        }
    }
}
