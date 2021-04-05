using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapContext>, IUserDal
    {
        public List<UserDetailDto> GetAllUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from user in filter == null ? context.Users : context.Users.Where(filter)

                    select new UserDetailDto
                    {
                       UserId = user.Id,
                       FirstName = user.FirstName,
                       LastName = user.LastName,
                       Email = user.Email,
                       OperationClaimsId = 
                       (from i in context.UserOperationClaims where i.UserId == user.Id select i.OperationClaimId).ToList(),

                    };
                return result.ToList();
            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }
    }
}
