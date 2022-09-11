using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.WebApi.Dtms.LoyaltyCard
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
