namespace DotnetSampleSolution.Core.Contracts
{
    public interface IReadWriteRepository<TEntity, TKey> : 
        IReadRepository<TEntity, TKey>, 
        IWriteRepository<TEntity, TKey> 
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
