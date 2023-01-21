using LoyaltyCardManager.Core.Contracts;

namespace LoyaltyCardManager.Core.Entities
{
    public class LoyaltyCardEntity
    {
        public int Id { get; set; }
        public string? MerchantName { get; set; }
        public string? MembershipId { get; set; }
        public int? GroupId { get; set; }
        public GroupEntity? Group { get; set; }
    }
}
