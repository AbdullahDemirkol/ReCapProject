using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            if (user.FirstName.Length<2 || user.LastName.Length<2)
            {
                return new ErrorResult(Messages.UserErrorAdded);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.UserSuccessAdded);
        }

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
            if (result==null)
            {
                return new ErrorDataResult<User>(Messages.UserErrorGetById);
            }
            return new SuccessDataResult<User>(result,Messages.UserSuccessGetById);
        }

        public IResult Update(User user)
        {
            if (user.FirstName.Length < 2 || user.LastName.Length < 2)
            {
                return new ErrorResult(Messages.UserErrorUpdated);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserSuccessUpdated);
        }
    }
}
