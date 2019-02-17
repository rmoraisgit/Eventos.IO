using FluentValidation.Results;
using RFL.Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Console.WriteLine("Notificar erros");
            }
        }

        protected bool Commit()
        {
            var commandResponse = _uow.Commit();

            if (commandResponse.Success) return true;

            // Notificar erro
            return false;
        }
    }
}
