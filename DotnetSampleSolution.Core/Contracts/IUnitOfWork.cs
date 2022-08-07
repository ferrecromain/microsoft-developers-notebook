namespace DotnetSampleSolution.Core.Contracts
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
