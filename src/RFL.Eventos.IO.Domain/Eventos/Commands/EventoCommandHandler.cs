using RFL.Eventos.IO.Domain.Core.Events;
using RFL.Eventos.IO.Domain.Eventos.Repository;
using RFL.Eventos.IO.Domain.Handlers;
using RFL.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _uow;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow) : base(uow)
        {
            _eventoRepository = eventoRepository;
            _uow = uow;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim,
                                    message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

            if (!evento.EhValido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
            }

            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                // Notificar processo concluído
            }
        }
    }
}
