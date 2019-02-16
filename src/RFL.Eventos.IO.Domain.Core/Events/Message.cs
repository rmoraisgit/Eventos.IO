using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Core.Events
{
    public abstract class Message
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public Guid AggregateId { get; protected set; }
        public string MessageType { get; protected set; }
    }
}
