using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c.Emaiil).NotEmpty();
            RuleFor(c => c.Emaiil).EmailAddress();
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.FirstName).MinimumLength(2);
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.LastName).MinimumLength(2);
        }
    }
}
