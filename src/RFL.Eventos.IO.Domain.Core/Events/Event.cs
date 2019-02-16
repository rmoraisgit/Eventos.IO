using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        protected Event()
        {
            Datestamp = DateTime.Now;
        }

        public DateTime Datestamp { get; private set; }
    }
}
