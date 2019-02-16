using System;
using System.Collections.Generic;
using System.Text;

namespace RFL.Eventos.IO.Domain.Eventos.Commands
{
    public class RegistrarEventoCommand : BaseEventoCommand
    {
        public RegistrarEventoCommand(
           string nome,
           DateTime dataInicio,
           DateTime dataFim,
           bool gratuito,
           decimal valor,
           bool online,
           string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            Online = online;
        }
    }
}
