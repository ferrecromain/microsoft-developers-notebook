using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.Core.Contracts
{
    public interface IGroupRepository : IReadWriteRepository<GroupEntity, int>
    {
    }
}
