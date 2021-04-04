using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users user)
        {
            _usersDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Users user)
        {
            _usersDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll());
        }

        public IDataResult<List<Users>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(p => p.Id == id));
        }

        public IResult Update(Users user)
        {
            _usersDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }
    }
}
