using LoyaltyCardManager.Core.Entities;

namespace LoyaltyCardManager.WebApi.Dtms.Group
{
    public class GroupGetDtm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GroupGetDtm() { }
        public GroupGetDtm(GroupEntity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
            Description = entity.Description;
        }
    }
}
