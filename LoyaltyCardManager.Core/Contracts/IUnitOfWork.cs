namespace LoyaltyCardManager.Core.Contracts
{
    public interface IUnitOfWork
    {
        public ILoyaltyCardRepository LoyaltyCardRepository { get; }
        Task SaveAsync();
    }
}
