using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.WebApi.Dtms.LoyaltyCard
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
