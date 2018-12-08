using System;
using IOTProject.CoreProject.Core.Commands;
using IOTProject.IOTProject.Domain.People;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands
{
    public abstract class HeartRateCommand : Command
    {
        public Person Person { get; protected set; }
        public int HeartRateValue { get; protected set; }

        public Guid HeartRateId { get; protected set; }
    }
}
