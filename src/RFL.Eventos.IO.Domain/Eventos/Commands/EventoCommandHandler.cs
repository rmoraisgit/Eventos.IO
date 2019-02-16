using RFL.Eventos.IO.Domain.Core.Events;
using RFL.Eventos.IO.Domain.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>
    {
        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim,
                                    message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

            if (!evento.EhValido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
            }
        }
    }
}
