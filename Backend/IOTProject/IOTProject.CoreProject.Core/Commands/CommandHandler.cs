using IOTProject.CoreProject.Core.Bus;
using IOTProject.CoreProject.Core.Notifications;
using MediatR;

namespace IOTProject.CoreProject.Core.Commands
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _inMemoryBus;

        protected readonly DomainNotificationHandler Notifications;


        public CommandHandler(IMediatorHandler inMemoryBus, INotificationHandler<DomainNotification> notifications)
        {
            _inMemoryBus = inMemoryBus;
            Notifications = (DomainNotificationHandler)notifications;
        }


        protected void NotifyValidationErrors(Command message)
        {
            foreach (var messageValidationResult in message.ValidationResults)
            {
                foreach (var error in messageValidationResult.Errors)
                {
                    _inMemoryBus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
                }
            }
        }

        protected void NotifyValidationErrorFromDomain(string type, string message)
        {
            _inMemoryBus.RaiseEvent(new DomainNotification(type, message));
        }

        protected void NotifyValidationErrorFromDomain(string message)
        {
            _inMemoryBus.RaiseEvent(new DomainNotification("DomainNotification", message));
        }
    }
}
