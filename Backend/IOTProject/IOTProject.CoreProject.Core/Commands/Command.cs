using System;
using System.Collections.Generic;
using FluentValidation.Results;
using IOTProject.CoreProject.Core.Interfaces.Abstract;

namespace IOTProject.CoreProject.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; }
        public List<ValidationResult> ValidationResults { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
