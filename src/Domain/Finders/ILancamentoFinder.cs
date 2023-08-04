using System;
using System.Threading.Tasks;
using CPObjects.Infrastructure.Finder;
using Domain.Finders.Models;

namespace Domain.Finders
{
    public interface ILancamentoFinder
    {
        Task<LancamentoModel> ObterPor(Guid aggregateId, Pagination pagination);
    }
}