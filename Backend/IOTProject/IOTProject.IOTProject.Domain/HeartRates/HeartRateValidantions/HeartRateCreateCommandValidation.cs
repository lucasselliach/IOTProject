using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateValidantions
{
    public class HeartRateCreateCommandValidation : HeartRateCommandValidation<HeartRateCreateCommand>
    {
        public HeartRateCreateCommandValidation()
        {
            PersonIsValid();
            HeartRateValueIsValid();
        }
    }
}
