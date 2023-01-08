using LoyaltyCardManager.Core.Contracts;

namespace LoyaltyCardManager.Core.Entities
{
    public class GroupEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<LoyaltyCardEntity> LoyaltyCards { get; set; } = default!;
    }
}
