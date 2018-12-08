using System;
using IOTProject.CoreProject.Core.Events;

namespace IOTProject.CoreProject.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; }
        public int Version { get; }
        public string Key { get; }
        public string Value { get; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}
