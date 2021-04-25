﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.UserId).GreaterThan(0);
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(5);
        }
    }
}
