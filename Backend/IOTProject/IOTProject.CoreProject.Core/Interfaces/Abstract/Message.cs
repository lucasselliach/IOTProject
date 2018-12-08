using System;
using MediatR;

namespace IOTProject.CoreProject.Core.Interfaces.Abstract
{
    public abstract class Message : INotification
    {
        public Guid AggregateId { get; protected set; }
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
