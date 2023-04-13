namespace LoyaltyCardManager.Core.Contracts
{
    public interface IUnitOfWork
    {
        public ILoyaltyCardRepository LoyaltyCardRepository { get; }
        public IGroupRepository GroupRepository { get; }
        Task SaveAsync();
    }
}
