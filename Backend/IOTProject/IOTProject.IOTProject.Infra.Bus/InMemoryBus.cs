using System.Threading.Tasks;
using IOTProject.CoreProject.Core.Bus;
using IOTProject.CoreProject.Core.Commands;
using IOTProject.CoreProject.Core.Events;
using IOTProject.CoreProject.Core.Interfaces.Abstract;
using MediatR;

namespace IOTProject.IOTProject.Infra.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return Publish(command);
        }

        public Task RaiseEvent<T>(T eventCommand) where T : Event
        {
            return Publish(eventCommand);
        }

        #region private method

        private Task Publish<T>(T message) where T : Message
        {
            return _mediator.Publish(message);
        }

        #endregion private method
    }
}
