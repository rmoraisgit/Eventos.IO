using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Events
{
    public class EventoRemovidoEvent : BaseEventoEvent
    {
        public EventoRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
