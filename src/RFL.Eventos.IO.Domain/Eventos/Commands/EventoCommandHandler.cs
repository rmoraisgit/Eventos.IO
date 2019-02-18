using RFL.Eventos.IO.Domain.Core.Bus;
using RFL.Eventos.IO.Domain.Core.Events;
using RFL.Eventos.IO.Domain.Core.Noitifications;
using RFL.Eventos.IO.Domain.Eventos.Events;
using RFL.Eventos.IO.Domain.Eventos.Repository;
using RFL.Eventos.IO.Domain.Handlers;
using RFL.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<RemoverEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _uow = uow;
            _bus = bus;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim,
                                    message.Gratuito, message.Valor, message.Online, message.NomeEmpresa);

            if (!EventoValido(evento)) return;

            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim,
                                    evento.Gratuito, evento.Valor, evento.Online, evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                                                                 message.DescricaoLonga, message.DataInicio, message.DataFim,
                                                                 message.Gratuito, message.Valor, message.Online,
                                                                 message.NomeEmpresa);

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoAtualizadoEvent(message.Id, message.Nome, message.DescricaoCurta,
                                                          message.DescricaoLonga, message.DataInicio, message.DataFim,
                                                          message.Gratuito, message.Valor, message.Online,
                                                          message.NomeEmpresa));
            }
        }

        public void Handle(RemoverEventoCommand message)
        {
            _eventoRepository.Remover(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new EventoRemovidoEvent(message.Id));
            }
        }

        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);
            return false;
        }
    }
}
