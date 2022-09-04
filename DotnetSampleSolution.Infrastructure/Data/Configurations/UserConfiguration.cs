using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetSampleSolution.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasData(
                new UserEntity() { Id = 1, FirstName = "Michael", LastName = "Wilson", Birthday = new DateTime(1989, 5, 12), Email = "michael.wilson@company.tld" },
                new UserEntity() { Id = 2, FirstName = "Jerry", LastName = "Whitehall", Birthday = new DateTime(1979, 10, 2), Email = "jerry.whitehall@company.tld" },
                new UserEntity() { Id = 3, FirstName = "Peter", LastName = "Parvin", Birthday = new DateTime(1984, 3, 8), Email = "peter.parvin@company.tld" },
                new UserEntity() { Id = 4, FirstName = "Mary", LastName = "Reed", Birthday = new DateTime(1989, 5, 12), Email = "mary.reed@company.tld" },
                new UserEntity() { Id = 5, FirstName = "Ducy", LastName = "Estevez", Birthday = new DateTime(1990, 11, 2), Email = "lucy.estevez@company.tld" },
                new UserEntity() { Id = 6, FirstName = "Donna", LastName = "Archer", Birthday = new DateTime(1985, 1, 25), Email = "donna.archer@company.tld" });
        }
    }
}
