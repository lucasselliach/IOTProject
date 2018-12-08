using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Interfaces.Repositories;

namespace IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        Person GetById(Guid id);
        IEnumerable<Person> GetAll();
        void Create(Person person);
        void Put(Person person);
        void Delete(Person person);
    }
}
