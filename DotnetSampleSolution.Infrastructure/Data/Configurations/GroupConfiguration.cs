using DotnetSampleSolution.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetSampleSolution.Infrastructure.Configurations
{
    internal class GroupConfiguration : IEntityTypeConfiguration<GroupEntity>
    {
        public void Configure(EntityTypeBuilder<GroupEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(
                new GroupEntity() { Id = 1, Name = "Design team", Description = "Formats the information provided by a website or an application through a set of contents" },
                new GroupEntity() { Id = 2, Name = "Development team", Description = "Responsible for all the work required to create functional and quality software." },
                new GroupEntity() { Id = 3, Name = "SEO & marketing", Description = "Works to promote products and services on the Internet" },
                new GroupEntity() { Id = 4, Name = "Finance/HR/Admin", Description = "Accountable for the sound financial, accounting, and budgetary management of the programs, and the management of human resources and administrative / legal records" }
            );
        }
    }
}
