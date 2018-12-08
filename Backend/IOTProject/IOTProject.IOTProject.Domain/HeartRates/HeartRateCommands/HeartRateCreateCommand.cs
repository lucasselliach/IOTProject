using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateValidantions;
using IOTProject.IOTProject.Domain.People;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands
{
    public class HeartRateCreateCommand : HeartRateCommand
    {
        public HeartRateCreateCommand(Person person, int heartRateValue)
        {
            Person = person;
            HeartRateValue = heartRateValue;
        }

        public override bool IsValid()
        {
            ValidationResults = new List<ValidationResult>
            {
                new HeartRateCreateCommandValidation().Validate(this)
            };

            return ValidationResults.All(x => x.IsValid);
        }
    }
}
