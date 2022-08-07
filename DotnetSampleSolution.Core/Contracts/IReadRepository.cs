using System.Linq.Expressions;

namespace DotnetSampleSolution.Core.Contracts
{
    public interface IReadRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey> 
        where TKey : IEquatable<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);
    }
}