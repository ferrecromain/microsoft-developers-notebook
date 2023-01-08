using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;

namespace LoyaltyCardManager.WebApi.Dtms.LoyaltyCard
{
    public class LoyaltyCardGetDtm
    {
        public int Id { get; set; }
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }

        public LoyaltyCardGetDtm(LoyaltyCardEntity entity)
        {
            Id = entity.Id;
            MerchantName = entity.MerchantName;
            MembershipId = entity.MembershipId;
        }
    }
}
