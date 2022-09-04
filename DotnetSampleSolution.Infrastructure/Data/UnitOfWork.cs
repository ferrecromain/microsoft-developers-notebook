using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure.Data
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public IUserRepository UserRepository => new UserRepository(_dbContext);
        public IGroupRepository GroupRepository => new GroupRepository(_dbContext);

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
