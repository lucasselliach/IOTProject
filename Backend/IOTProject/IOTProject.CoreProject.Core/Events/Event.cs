using System;
using IOTProject.CoreProject.Core.Interfaces.Abstract;

namespace IOTProject.CoreProject.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
