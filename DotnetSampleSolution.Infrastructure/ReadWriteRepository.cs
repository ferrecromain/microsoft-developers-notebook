using DotnetSampleSolution.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure
{
    public class ReadWriteRepository<TEntity, TKey> : 
        ReadRepository<TEntity, TKey>, 
        IReadWriteRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public ReadWriteRepository(DbContext dbContext) : base(dbContext) { }
        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
