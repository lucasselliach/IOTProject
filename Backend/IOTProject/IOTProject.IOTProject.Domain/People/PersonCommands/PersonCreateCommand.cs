using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using IOTProject.IOTProject.Domain.People.PersonValidations;

namespace IOTProject.IOTProject.Domain.People.PersonCommands
{
    public class PersonCreateCommand : PersonCommand
    {
        public PersonCreateCommand(string name, string email, DateTime birthDate, bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            IsFitness = isFitness;
            IsSmoker = isSmoker;
            HasCardiovascularDisease = hasCardiovascularDisease;
            HasHighCholesterol = hasHighCholesterol;
            HasDiabetes = hasDiabetes;
        }

        public override bool IsValid()
        {
            ValidationResults = new List<ValidationResult>
            {
                new PersonCreateCommandValidation().Validate(this)
            };

            return ValidationResults.All(x => x.IsValid);
        }
    }
}
