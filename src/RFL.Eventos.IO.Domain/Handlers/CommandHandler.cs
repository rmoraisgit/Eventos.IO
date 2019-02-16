using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Handlers
{
    public abstract class CommandHandler
    {
        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Console.WriteLine("Notificar erros");
            }
        }
    }
}
