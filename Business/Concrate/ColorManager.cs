using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorSuccessAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorSuccessDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorErrorListed);
            }
            return new SuccessDataResult<List<Color>>(result, Messages.ColorSuccessListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(p => p.ColorId == colorId);
            if (result==null)
            {
                return new ErrorDataResult<Color>(Messages.ColotErrorGetById);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId), Messages.ColorSuccessGetById);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorSuccessUpdated);
        }
    }
}
