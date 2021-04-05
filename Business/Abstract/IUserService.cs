using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
        IDataResult<List<UserDetailDto>> GetAllUserDetails();
        IDataResult<List<UserDetailDto>> GetAllUserDetailsByEmail(string email);

    }
}
