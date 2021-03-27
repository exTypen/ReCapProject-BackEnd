using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id boş olamaz");
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Açıklama en az 2 karakter olmalı");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Ücret boş olamaz");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Ücret 0'dan büyük olmalı");
        }
    }
}
