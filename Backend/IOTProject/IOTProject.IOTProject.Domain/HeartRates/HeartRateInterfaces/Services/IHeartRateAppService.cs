using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Interfaces.Services;
using IOTProject.IOTProject.Domain.People;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Services;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Services
{
    public interface IHeartRateAppService : IPersonSharedService, IServiceBase<HeartRate>
    {
        HeartRate GetHeartRateById(Guid id);
        IEnumerable<HeartRate> GetHeartRatesByPersonId(Guid personId);
        void CreateHeartRate(Person person, int heartRateValue);
        void DeleteHeartRate(Guid heartRateId);
    }
}
