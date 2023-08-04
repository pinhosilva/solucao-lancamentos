using CPObjects.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infra.EF.Data
{
    public class Repository : IRepository
    {
        protected readonly SolutionContext DbContext;

        public Repository(SolutionContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : Aggregate
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity> GetByAsync<TEntity>(int id) where TEntity : Aggregate
        {
            var entity = DbContext.Set<TEntity>().Local.SingleOrDefault(x => x.Id == id);
            return entity ?? await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByAsync<TEntity>(Guid aggregateId) where TEntity : Aggregate
        {
            var entity = DbContext.Set<TEntity>().Local.SingleOrDefault(x => x.AggregateId == aggregateId);
            return entity ?? await DbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.AggregateId == aggregateId);
        }

        public Task<TEntity> GetByAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : Aggregate
        {
            return DbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public Task<bool> ExistAsync<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : Aggregate
        {
            return DbContext.Set<TEntity>().AsNoTracking().AnyAsync(filter);
        }
    }
}