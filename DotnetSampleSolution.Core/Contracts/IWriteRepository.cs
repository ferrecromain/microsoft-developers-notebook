namespace DotnetSampleSolution.Core.Contracts
{
    public interface IWriteRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
