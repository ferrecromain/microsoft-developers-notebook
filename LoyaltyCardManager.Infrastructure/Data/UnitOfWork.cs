using LoyaltyCardManager.Core.Contracts;
using LoyaltyCardManager.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LoyaltyCardManager.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public ILoyaltyCardRepository LoyaltyCardRepository => new LoyaltyCardRepository(_dbContext);
        public IGroupRepository GroupRepository => new GroupRepository(_dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
