using System;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands
{
    public class HeartRateDeleteCommand : HeartRateCommand
    {
        public HeartRateDeleteCommand(Guid heartRateId)
        {
            HeartRateId = heartRateId;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
