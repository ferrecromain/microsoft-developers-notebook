using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure.Data.Repositories
{
    public class LoyaltyCardRepository : ReadWriteRepository<LoyaltyCardEntity, int>, ILoyaltyCardRepository
    {
        public LoyaltyCardRepository(DbContext dbContext) : base(dbContext) { }
    }
}
