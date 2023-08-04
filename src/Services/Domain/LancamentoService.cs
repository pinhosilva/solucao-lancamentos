using CPObjects.Infrastructure.Data;
using Domain.Aggregates;
using Domain.Services;
using System;
using System.Threading.Tasks;

namespace Services.Domain
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IRepository _repository;

        public LancamentoService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task CriarAsync(Guid aggregateId)
        {
            var aggregate = new LancamentoAggregate(aggregateId);
            await _repository.AddAsync(aggregate);
        }

        public async Task DebitarAsync(Guid aggregateId, decimal valor)
        {
            var aggregate = await _repository.GetByAsync<LancamentoAggregate>(aggregateId);
            aggregate.LancarDebito(valor);
        }

        public async Task CreditarAsync(Guid aggregateId, decimal valor)
        {
            var aggregate = await _repository.GetByAsync<LancamentoAggregate>(aggregateId);
            aggregate.LancarCredito(valor);
        }
    }
}