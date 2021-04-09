using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<UserDetailDto>> GetAllUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUserDetails());
        }

        public IDataResult<List<UserDetailDto>> GetAllUserDetailsByEmail(string email)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUserDetails(u=>u.Email == email));
        }

        public IDataResult<List<UserDetailDto>> GetAllUserDetailsById(int id)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUserDetails(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
