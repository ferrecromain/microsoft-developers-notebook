﻿using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetSampleSolution.Infrastructure.Configurations
{
    internal class LoyaltyCardConfiguration : IEntityTypeConfiguration<LoyaltyCardEntity>
    {
        public void Configure(EntityTypeBuilder<LoyaltyCardEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasData(
                new LoyaltyCardEntity() { Id = 1, MerchantName = "Los pollos hermanos", MembershipId = "0035595443" },
                new LoyaltyCardEntity() { Id = 2, MerchantName = "Big Kahuna burger", MembershipId = "2178445" },
                new LoyaltyCardEntity() { Id = 3, MerchantName = "Oceanic Airlines", MembershipId = "6259663200" }
            );
        }
    }
}