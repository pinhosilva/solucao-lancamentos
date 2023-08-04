using CPObjects.Infrastructure.Data;
using Domain.Events.Lancamentos;
using System;

namespace Domain.Aggregates
{
    public class LancamentoAggregate : Aggregate
    {
        public decimal Saldo { get; private set; }

        protected override void RegisterEvents()
        {
            SubscribeTo<LancamentoCriado>(e =>
            {
                AggregateId = e.AggregateId;
                TimeStamp = DateTime.Now;
                Saldo = e.Valor;
            });

            SubscribeTo<CreditoLancado>(e =>
            {
                Saldo += e.Valor;
            });

            SubscribeTo<DebitoLancado>(e =>
            {
                Saldo -= e.Valor;
            });
        }

        public LancamentoAggregate() { }

        public LancamentoAggregate(Guid aggregate)
        {
            Emit(new LancamentoCriado(aggregate, 0));
        }

        public void LancarCredito(decimal valor)
        {
            Emit(new CreditoLancado(AggregateId, valor));
        }

        public void LancarDebito(decimal valor)
        {
            Emit(new DebitoLancado(AggregateId, valor));
        }
    }
}