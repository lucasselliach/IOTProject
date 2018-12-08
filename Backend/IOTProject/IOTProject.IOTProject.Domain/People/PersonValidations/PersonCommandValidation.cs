using System;
using FluentValidation;
using IOTProject.IOTProject.Domain.People.PersonCommands;

namespace IOTProject.IOTProject.Domain.People.PersonValidations
{
    public abstract class PersonCommandValidation<T> : AbstractValidator<T> where T : PersonCommand
    {
        protected void NameIsValid()
        {
            RuleFor(c => c.Name)
                .NotNull().WithMessage("Name can not be null.")
                .NotEmpty().WithMessage("Name can not be empty.")
                .MinimumLength(3).WithMessage("Name cannot be less than 3 characters")
                .MaximumLength(100).WithMessage("Name cannot be bigger than 100 characters.");
        }

        protected void EmailIsValid()
        {
            RuleFor(c => c.Email)
                .NotNull().WithMessage("Email cannot be null.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .MinimumLength(3).WithMessage("Email cannot be less than 3 characters")
                .MaximumLength(100).WithMessage("Email cannot be bigger than 100 characters.");
        }

        protected void BirthDateIsValid()
        {
            RuleFor(c => c.BirthDate)
                .NotNull().WithMessage("BirthDate cannot be null.")
                .Must(x => x.Date > DateTime.Parse("1900-01-01")).WithMessage("BirthDate needs be bigger than 01/01/1900");
        }
    }
}
