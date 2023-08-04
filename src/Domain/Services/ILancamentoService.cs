using System;
using System.Threading.Tasks;
using Infrastructure.Core;

namespace Domain.Services
{
    public interface ILancamentoService : IService
    {
        Task CriarAsync(Guid aggregateId);
        Task DebitarAsync(Guid aggregateId, decimal valor);
        Task CreditarAsync(Guid aggregateId, decimal valor);
    }
}