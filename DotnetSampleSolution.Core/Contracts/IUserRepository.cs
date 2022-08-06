using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.Core.Contracts
{
    public interface IUserRepository : IReadWriteRepository<UserEntity, int>
    {
    }
}
