using DotnetSampleSolution.Core.Contracts;
using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotnetSampleSolution.Infrastructure.Data.Repositories
{
    public class UserRepository : ReadWriteRepository<UserEntity, int>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext) { }
    }
}
