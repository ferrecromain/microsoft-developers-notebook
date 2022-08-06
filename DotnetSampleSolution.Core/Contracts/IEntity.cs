namespace DotnetSampleSolution.Core.Contracts
{
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }
}
