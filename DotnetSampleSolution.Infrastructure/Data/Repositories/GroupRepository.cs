using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure.Data.Repositories
{
    public class GroupRepository : ReadWriteRepository<GroupEntity, int>, IGroupRepository
    {
        public GroupRepository(DbContext dbContext) : base(dbContext) { }
    }
}