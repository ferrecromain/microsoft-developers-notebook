using DotnetSampleSolution.Core.Entities;
using DotnetSampleSolution.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetSampleSolution.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        /// <remarks>
        /// * Warning CS8618 : https://docs.microsoft.com/fr-fr/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset
        /// </remarks>
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<GroupEntity> Groups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(p => p.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "application"));
            optionsBuilder.UseSqlite(p => p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
