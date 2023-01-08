namespace LoyaltyCardManager.Core.Contracts
{
    public interface IReadWriteRepository<TEntity> : 
        IReadRepository<TEntity>
        where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
