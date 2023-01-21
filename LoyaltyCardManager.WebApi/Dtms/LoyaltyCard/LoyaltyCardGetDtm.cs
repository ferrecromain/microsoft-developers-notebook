using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;
using System.Text.Json.Serialization;

namespace LoyaltyCardManager.WebApi.Dtms.LoyaltyCard
{
    public class LoyaltyCardGetDtm
    {
        public int Id { get; set; }
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }

        public LoyaltyCardGetDtm() { }
        public LoyaltyCardGetDtm(LoyaltyCardEntity entity)
        {
            Id = entity.Id;
            MerchantName = entity.MerchantName;
            MembershipId = entity.MembershipId;
        }
    }
}
