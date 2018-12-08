using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using IOTProject.IOTProject.Domain.People.PersonValidations;

namespace IOTProject.IOTProject.Domain.People.PersonCommands
{
    public class PersonEditNameEmailBirthDateCommand : PersonCommand
    {
        public PersonEditNameEmailBirthDateCommand(string name, string email, DateTime birthDate, Guid personId)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;

            PersonId = personId;
        }

        public override bool IsValid()
        {
            ValidationResults = new List<ValidationResult>
            {
                new PersonEditNameEmailBirthDateCommandValidation().Validate(this)
            };

            return ValidationResults.All(x => x.IsValid);
        }
    }
}
