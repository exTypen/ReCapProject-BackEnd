using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult CheckCreditCard(CreditCard creditCard)
        {
            var rentalledCars = _creditCardDal.Get(c => c.CardNumber == creditCard.CardNumber && c.CardMonth == creditCard.CardMonth && c.CardYear == creditCard.CardYear && c.CardCcv == creditCard.CardCcv);

            if (rentalledCars == null)
            {
                return new ErrorResult(Messages.CreditIsNotExist);
            }
            else
            {
                return new SuccessResult("Credit Kartı doğrulandı");
            }
           

        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }
    }
}
