using LoyaltyCardManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoyaltyCardManager.Infrastructure.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Group");
            builder.HasData(
                new GroupEntity() { Id = 1, Name = "Restaurants", Description = "Fast Food and casual Dining" },
                new GroupEntity() { Id = 2, Name = "Transports", Description = "Airlines, railways companies" }
            );
        }
    }
}
