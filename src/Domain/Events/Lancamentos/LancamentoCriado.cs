using CPObjects.Infrastructure.Events;
using System;

namespace Domain.Events.Lancamentos
{
    public class LancamentoCriado : DomainEvent
    {
        public decimal Valor { get; }

        public LancamentoCriado(Guid aggregateId, decimal valor) : base(aggregateId)
        {
            Valor = valor;
        }
    }
}