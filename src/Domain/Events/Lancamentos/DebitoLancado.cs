using CPObjects.Infrastructure.Events;
using System;

namespace Domain.Events.Lancamentos
{
    public class DebitoLancado : DomainEvent
    {
        public decimal Valor { get; }
        public DebitoLancado(Guid aggregateId, decimal valor) : base(aggregateId)
        {
            Valor = valor;
        }
    }
}