using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;

namespace LoyaltyCardManager.WebApi.Dtms.LoyaltyCard
{
    public class LoyaltyCardPostDtm : IMappableTo<LoyaltyCardEntity>
    {
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }

        public LoyaltyCardEntity MapTo(LoyaltyCardEntity entity)
        {
            entity.MerchantName = MerchantName;
            entity.MembershipId = MembershipId;
            return entity;
        }
    }
}
