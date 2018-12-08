using System;
using IOTProject.CoreProject.Core.Commands;

namespace IOTProject.IOTProject.Domain.People.PersonCommands
{
    public abstract class PersonCommand : Command
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public DateTime BirthDate { get; protected set; }
        public bool IsFitness { get; protected set; }
        public bool IsSmoker { get; protected set; }
        public bool HasCardiovascularDisease { get; protected set; }
        public bool HasHighCholesterol { get; protected set; }
        public bool HasDiabetes { get; protected set; }

        public Guid PersonId { get; protected set; }
    }
}
