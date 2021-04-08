using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult CheckCreditCard(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll();
    }
}
