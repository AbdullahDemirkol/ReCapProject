using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        [SecuredOperation("brand.add,moderator")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorSuccessAdded);
        }


        [SecuredOperation("brand.delete,admin")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorSuccessDeleted);
        }


        [SecuredOperation("brand.list,user")]
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorErrorListed);
            }
            return new SuccessDataResult<List<Color>>(result, Messages.ColorSuccessListed);
        }


        [SecuredOperation("brand.list,moderator")]
        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(p => p.ColorId == colorId);
            if (result==null)
            {
                return new ErrorDataResult<Color>(Messages.ColotErrorGetById);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == colorId), Messages.ColorSuccessGetById);
        }


        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorSuccessUpdated);
        }
    }
}
