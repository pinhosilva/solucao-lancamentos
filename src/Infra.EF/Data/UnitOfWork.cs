using Infrastructure.Core;
using System;
using System.Threading.Tasks;

namespace Infra.EF.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SolutionContext _context;

        public UnitOfWork(SolutionContext context)
        {
            _context = context;
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}