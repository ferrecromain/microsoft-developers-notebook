using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyCardManager.Infrastructure.Data.Repositories
{
    public class LoyaltyCardRepository : ReadWriteRepository<LoyaltyCardEntity>, ILoyaltyCardRepository
    {
        public LoyaltyCardRepository(DbContext dbContext) : base(dbContext) { }
    }
}
