using FluentValidation;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateValidantions
{
    public abstract class HeartRateCommandValidation<T> : AbstractValidator<T> where T : HeartRateCommand
    {
        protected void PersonIsValid()
        {
            RuleFor(c => c.Person)
                .NotNull().WithMessage("Person can not be null.");
        }

        protected void HeartRateValueIsValid()
        {
            RuleFor(c => c.HeartRateValue)
                .GreaterThanOrEqualTo(1).WithMessage("HeartRate value should be bigger than one.");
        }
    }
}
