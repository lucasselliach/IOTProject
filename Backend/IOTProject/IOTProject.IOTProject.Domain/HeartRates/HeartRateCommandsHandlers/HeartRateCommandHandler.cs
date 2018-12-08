using System.Threading;
using System.Threading.Tasks;
using IOTProject.CoreProject.Core.Bus;
using IOTProject.CoreProject.Core.Commands;
using IOTProject.CoreProject.Core.Notifications;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateCommands;
using IOTProject.IOTProject.Domain.HeartRates.HeartRateInterfaces.Repositories;
using MediatR;

namespace IOTProject.IOTProject.Domain.HeartRates.HeartRateCommandsHandlers
{
    public class HeartRateCommandHandler : CommandHandler, INotificationHandler<HeartRateCreateCommand>, INotificationHandler<HeartRateDeleteCommand>
    {
        private readonly IHeartRateRepository _heartRateRepository;

        public HeartRateCommandHandler(IMediatorHandler inMemoryBus, INotificationHandler<DomainNotification> notifications, IHeartRateRepository heartRateRepository) : base(inMemoryBus, notifications)
        {
            _heartRateRepository = heartRateRepository;
        }
        
        public Task Handle(HeartRateCreateCommand heartRateCreateCommand, CancellationToken cancellationToken)
        {
            var newHeartRate = new HeartRate(heartRateCreateCommand.Person,
                                             heartRateCreateCommand.HeartRateValue);

            _heartRateRepository.Create(newHeartRate);

            return Task.CompletedTask;
        }

        public Task Handle(HeartRateDeleteCommand heartRateDeleteCommand, CancellationToken cancellationToken)
        {
            if (!heartRateDeleteCommand.IsValid())
            {
                NotifyValidationErrors(heartRateDeleteCommand);
                return Task.CompletedTask;
            }

            var heartRate = _heartRateRepository.GetById(heartRateDeleteCommand.HeartRateId);
            _heartRateRepository.Delete(heartRate);

            return Task.CompletedTask;
        }
    }
}
