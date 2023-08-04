using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}