using Entities.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(2);
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(2);
            //RuleFor(p => p.Email).Must(EmailValidation).WithMessage("Email adresi hatalı.");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir eposta adresi gerekli.");
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Email).MinimumLength(6);
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı.");

        }

        //private bool EmailValidation(string arg)
        //{
        //    var result = arg.IndexOf("@", 0, arg.Length);
        //    if (result==-1)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
