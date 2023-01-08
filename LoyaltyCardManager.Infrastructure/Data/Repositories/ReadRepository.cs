using LoyaltyCardManager.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LoyaltyCardManager.Infrastructure.Data.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _dbContext;

        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            IQueryable<TEntity> request = _dbContext.Set<TEntity>();
            if (filter != null)
                request = request.Where(filter);
            return await request.ToListAsync();
        }

        public async Task<TEntity?> GetAsync(params object[] keyValues)
        {
            return await _dbContext.Set<TEntity>().FindAsync(keyValues);
        }
    }
}