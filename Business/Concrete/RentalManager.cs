using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CarRentedCheck(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult("rental added");  
        }

        public IResult Update(Rental rental)
        {
            throw new NotImplementedException();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult CarRentedCheck(Rental rental)
        {
            var rentalledCars = _rentalDal.GetAll( r => r.CarId == rental.CarId && (r.ReturnDate > rental.RentDate)).Any();

            if (rentalledCars)
            {
                var rentalledCars2 = _rentalDal.GetAll(r => r.CarId == rental.CarId && (rental.ReturnDate < r.RentDate))
                    .Any();
                if (rentalledCars2)
                {
                    return new SuccessResult();
                }

                return new ErrorResult(Messages.CarRented);
            }
            return new SuccessResult();
        }

        
    }
}
