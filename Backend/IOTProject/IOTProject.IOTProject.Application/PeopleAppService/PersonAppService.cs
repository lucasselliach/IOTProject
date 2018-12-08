using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Bus;
using IOTProject.IOTProject.Domain.People;
using IOTProject.IOTProject.Domain.People.PersonCommands;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Services;

namespace IOTProject.IOTProject.Application.PeopleAppService
{
    public class PersonAppService : IPersonService
    {
        private readonly IMediatorHandler _inMemoryBus;
        private readonly IPersonRepository _personRepository;

        public PersonAppService(IMediatorHandler inMemoryBus, IPersonRepository personRepository)
        {
            _inMemoryBus = inMemoryBus;
            _personRepository = personRepository;
        }

        public Person GetPersonById(Guid id)
        {
            return _personRepository.GetById(id);
        }

        public IEnumerable<Person> GetPeople()
        {
            return _personRepository.GetAll();
        }

        public void CreatePerson(string name, string email, DateTime birthDate, bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes)
        {
            _inMemoryBus.SendCommand(new PersonCreateCommand(name, email, birthDate, isFitness, isSmoker, hasCardiovascularDisease, hasHighCholesterol, hasDiabetes));
        }

        public void ChangePersonNameEmailBirthDate(string name, string email, DateTime birthDate, Guid personId)
        {
            _inMemoryBus.SendCommand(new PersonEditNameEmailBirthDateCommand(name, email, birthDate, personId));
        }

        public void ChangePersonHealthInformation(bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes, Guid personId)
        {
            _inMemoryBus.SendCommand(new PersonEditHealthInformationCommand(isFitness, isSmoker, hasCardiovascularDisease, hasHighCholesterol, hasDiabetes, personId));
        }

        public void DeletePerson(Guid personId)
        {
            _inMemoryBus.SendCommand(new PersonDeleteCommand(personId));
        }
    }
}
