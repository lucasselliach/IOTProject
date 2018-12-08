using System.Threading.Tasks;
using IOTProject.CoreProject.Core.Commands;
using IOTProject.CoreProject.Core.Events;

namespace IOTProject.CoreProject.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
