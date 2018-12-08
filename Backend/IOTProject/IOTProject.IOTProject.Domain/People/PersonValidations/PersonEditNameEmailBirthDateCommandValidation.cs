using IOTProject.IOTProject.Domain.People.PersonCommands;

namespace IOTProject.IOTProject.Domain.People.PersonValidations
{
    public class PersonEditNameEmailBirthDateCommandValidation : PersonCommandValidation<PersonEditNameEmailBirthDateCommand>
    {
        public PersonEditNameEmailBirthDateCommandValidation()
        {
            NameIsValid();
            EmailIsValid();
            BirthDateIsValid();
        }
    }
}
