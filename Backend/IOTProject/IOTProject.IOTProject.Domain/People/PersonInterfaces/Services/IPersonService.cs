using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Interfaces.Services;

namespace IOTProject.IOTProject.Domain.People.PersonInterfaces.Services
{
    public interface IPersonService : IServiceBase<Person>
    {
        Person GetPersonById(Guid id);
        IEnumerable<Person> GetPeople();
        void CreatePerson(string name, string email, DateTime birthDate, bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes);
        void ChangePersonNameEmailBirthDate(string name, string email, DateTime birthDate, Guid personId);
        void ChangePersonHealthInformation(bool isFitness, bool isSmoker, bool hasCardiovascularDisease, bool hasHighCholesterol, bool hasDiabetes, Guid personId);
        void DeletePerson(Guid personId);
    }
}
