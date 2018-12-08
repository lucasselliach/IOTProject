using System;
using System.Collections.Generic;
using IOTProject.CoreProject.Core.Bus;
using IOTProject.IOTProject.Domain.HeartRates;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Repositories;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Services;
using IOTProject.IOTProject.Domain.People;
using IOTProject.IOTProject.Domain.People.PersonInterfaces.Repositories;

namespace IOTProject.IOTProject.Application.HeartRatesAppService
{
    public class HeartRateAppService : IHeartRateAppService
    {
        private readonly IMediatorHandler _inMemoryBus;
        private readonly IHeartRateRepository _heartRateRepository;
        private readonly IPersonRepository _personRepository;

        public HeartRateAppService(IMediatorHandler inMemoryBus, IHeartRateRepository heartRateRepository, IPersonRepository personRepository)
        {
            _inMemoryBus = inMemoryBus;
            _heartRateRepository = heartRateRepository;
            _personRepository = personRepository;
        }

        public Person GetPersonById(Guid id)
        {
            return _personRepository.GetById(id);
        }

        public HeartRate GetHeartRateById(Guid id)
        {
            return _heartRateRepository.GetById(id);
        }

        public IEnumerable<HeartRate> GetHeartRatesByPersonId(Guid personId)
        {
            return _heartRateRepository.GetByPersonId(personId);
        }

        public void CreateHeartRate(Person person, int heartRateValue)
        {
            _inMemoryBus.SendCommand(new HeartRateCreateCommand(person, heartRateValue));
        }

        public void DeleteHeartRate(Guid heartRateId)
        {
            _inMemoryBus.SendCommand(new HeartRateDeleteCommand(heartRateId));
        }
    }
}
