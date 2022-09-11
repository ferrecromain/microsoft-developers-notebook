using DotnetSampleSolution.Core.Contracts;

namespace DotnetSampleSolution.Core.Entities
{
    public class LoyaltyCardEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }
    }
}
