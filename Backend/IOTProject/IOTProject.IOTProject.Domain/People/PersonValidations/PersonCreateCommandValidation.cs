using IOTProject.IOTProject.Domain.People.PersonCommands;

namespace IOTProject.IOTProject.Domain.People.PersonValidations
{
    public class PersonCreateCommandValidation : PersonCommandValidation<PersonCreateCommand>
    {
        public PersonCreateCommandValidation()
        {
            NameIsValid();
            EmailIsValid();
            BirthDateIsValid();
        }
    }
}
