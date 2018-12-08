using System;

namespace IOTProject.IOTProject.Domain.People.PersonCommands
{
    public class PersonEditHealthInformationCommand : PersonCommand
    {
        public PersonEditHealthInformationCommand(bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes, Guid personId)
        {
            IsFitness = isFitness;
            IsSmoker = isSmoker;
            HasCardiovascularDisease = hasCardiovascularDisease;
            HasHighCholesterol = hasHighCholesterol;
            HasDiabetes = hasDiabetes;

            PersonId = personId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
