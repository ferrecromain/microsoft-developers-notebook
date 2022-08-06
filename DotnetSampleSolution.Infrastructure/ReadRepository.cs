using DotnetSampleSolution.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotnetSampleSolution.Infrastructure
{
    public class ReadRepository<TEntity, TKey> : IReadRepository<TEntity, TKey> 
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly DbContext _dbContext;

        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbContext.Set<TEntity>().SingleAsync(e => e.Id.Equals(id));
        }
    }
}