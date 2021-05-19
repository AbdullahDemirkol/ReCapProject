using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }


        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }


        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserSuccessAdded);
        }


        [SecuredOperation("user.delete,admin")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserSuccessDeleted);
        }


        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<User>>(Messages.UserErrorListed);
            }
            return new SuccessDataResult<List<User>>( result,Messages.UserSuccessListed);
        }


        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(p => p.Id == userId);
            if (result == null)
            {
                return new ErrorDataResult<User>(Messages.UserErrorGetById);
            }
            return new SuccessDataResult<User>(result, Messages.UserSuccessGetById);
        }


        [SecuredOperation("user.update,admin")]
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserSuccessUpdated);
        }

    }
}
