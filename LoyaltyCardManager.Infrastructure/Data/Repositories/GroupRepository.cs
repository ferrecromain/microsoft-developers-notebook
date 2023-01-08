using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyCardManager.Infrastructure.Data.Repositories
{
    public class GroupRepository : ReadWriteRepository<GroupEntity>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext) { }
    }
}