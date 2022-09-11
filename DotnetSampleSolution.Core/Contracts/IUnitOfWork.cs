namespace DotnetSampleSolution.Core.Contracts
{
    public interface IUnitOfWork
    {
        public ILoyaltyCardRepository LoyaltyCardRepository { get; }
        Task SaveAsync();
    }
}
