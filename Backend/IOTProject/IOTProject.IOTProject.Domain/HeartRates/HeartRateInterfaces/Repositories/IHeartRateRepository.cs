using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Interfaces.Repositories;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Repositories
{
    public interface IHeartRateRepository : IRepositoryBase<HeartRate>
    {
        HeartRate GetById(Guid id);
        IEnumerable<HeartRate> GetByPersonId(Guid personId);
        IEnumerable<HeartRate> GetAll();
        void Create(HeartRate person);
        void Delete(HeartRate person);
    }
}
