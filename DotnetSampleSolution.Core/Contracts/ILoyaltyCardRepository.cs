using DotnetSampleSolution.Core.Entities;

namespace DotnetSampleSolution.Core.Contracts
{
    public interface ILoyaltyCardRepository : IReadWriteRepository<LoyaltyCardEntity, int>
    {
    }
}
