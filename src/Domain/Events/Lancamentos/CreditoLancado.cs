using System;
using CPObjects.Infrastructure.Events;

namespace Domain.Events.Lancamentos
{
    public class CreditoLancado : DomainEvent
    {
        public decimal Valor { get; }
        public CreditoLancado(Guid aggregateId, decimal valor) : base(aggregateId)
        {
            Valor = valor;
        }
    }
}