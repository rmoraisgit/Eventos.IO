using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Commands
{
    public class RemoverEventoCommand : BaseEventoCommand
    {
        public RemoverEventoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
