using System;

namespace IOTProject.IOTProject.Domain.People.PersonCommands
{
    public class PersonDeleteCommand : PersonCommand
    {
        public PersonDeleteCommand(Guid personId)
        {
            PersonId = personId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
