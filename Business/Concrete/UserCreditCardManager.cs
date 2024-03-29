﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserCreditCardManager : IUserCreditCardService
    {
        private IUserCreditCardDal _userCreditCardDal;

        public UserCreditCardManager(IUserCreditCardDal userCreditCardDal)
        {
            _userCreditCardDal = userCreditCardDal;
        }

        public IResult Add(UserCreditCard userCreditCard)
        {
            _userCreditCardDal.Add(userCreditCard);
            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(UserCreditCard userCreditCard)
        {
            _userCreditCardDal.Delete(userCreditCard);
            return new SuccessResult();
        }

        public IDataResult<List<UserCreditCard>> GetCardIdsByUserId(int id)
        {
            return new SuccessDataResult<List<UserCreditCard>>(_userCreditCardDal.GetAll(c => c.UserId == id));
        }
    }
}
