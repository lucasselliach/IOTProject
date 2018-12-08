using System;
using IOTProject.CoreProject.Core.Interfaces.Services;

namespace IOTProject.IOTProject.Domain.People.PersonInterfaces.Services
{
    public interface IPersonSharedService : IServiceBase<Person>
    {
        Person GetPersonById(Guid id);
    }
}
