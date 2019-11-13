using ContactsApi.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApi.Validators
{
    public class ContactsValidator : AbstractValidator<Contacts>
    {
        public ContactsValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not a valid email address.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is mandatory.");
        }
    }
}
