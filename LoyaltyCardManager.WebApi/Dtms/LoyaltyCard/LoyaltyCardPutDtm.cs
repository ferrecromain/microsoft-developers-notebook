using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;

namespace LoyaltyCardManager.WebApi.Dtms.LoyaltyCard
{
    public class LoyaltyCardPutDtm : IMappableTo<LoyaltyCardEntity>
    {
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }

        public LoyaltyCardEntity MapTo(LoyaltyCardEntity model)
        {
            model.MerchantName = MerchantName;
            model.MembershipId = MembershipId;
            return model;
        }
    }
}
