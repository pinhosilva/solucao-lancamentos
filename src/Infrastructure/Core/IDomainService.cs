using System;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public interface IDomainService
    {
        IDomainService NewGuid(out Guid aggregateId);

        IDomainService Execute<TService>(Func<TService, Task> srv);

        Task CommitAsync();
    }
}