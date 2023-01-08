namespace LoyaltyCardManager.Core.Contracts
{
    public interface IMappableTo<TModel>
    {
        TModel MapTo(TModel model);
    }
}
