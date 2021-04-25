using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IResult Add(User user);
        User GetByEmail(string email);
        IResult Delete(User user);
        IResult Update(User user);
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
    }
}
