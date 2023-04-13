using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;

namespace LoyaltyCardManager.WebApi.Dtms.Group
{
    public class GroupPutDtm : IMappableTo<GroupEntity>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public GroupEntity MapTo(GroupEntity entity)
        {
            entity.Name = Name;
            entity.Description = Description;
            return entity;
        }
    }
}
