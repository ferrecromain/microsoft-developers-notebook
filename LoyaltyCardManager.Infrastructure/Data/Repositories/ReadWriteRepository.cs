using LoyaltyCardManager.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyCardManager.Infrastructure.Data.Repositories
{
    public class ReadWriteRepository<TEntity> :
        ReadRepository<TEntity>, IReadWriteRepository<TEntity> where TEntity : class
    {
        public ReadWriteRepository(DbContext dbContext) : base(dbContext) { }
        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
