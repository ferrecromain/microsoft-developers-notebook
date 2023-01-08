using System.Linq.Expressions;

namespace LoyaltyCardManager.Core.Contracts
{
    public interface IReadRepository<TEntity> 
        where TEntity : class
    {
        Task<TEntity?> GetAsync(params object[] keyValues);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>>? filter = null);
    }
}