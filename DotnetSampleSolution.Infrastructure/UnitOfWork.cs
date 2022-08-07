using DotnetSampleSolution.Core.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
