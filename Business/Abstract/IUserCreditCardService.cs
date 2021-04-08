using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserCreditCardService
    {
        IResult Add(UserCreditCard userCreditCard);
        IResult Delete(UserCreditCard userCreditCard);
    }
}
