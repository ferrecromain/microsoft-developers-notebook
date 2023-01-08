using LoyaltyCardManager.Core.Entities;
using LoyaltyCardManager.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoyaltyCardManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <remarks>
        /// * Warning CS8618 : https://docs.microsoft.com/fr-fr/ef/core/miscellaneous/nullable-reference-types#dbcontext-and-dbset
        /// </remarks>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(p => p.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "loyaltycardmanager"));
            optionsBuilder.UseSqlite(p => p.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoyaltyCardConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
        }
    }
}
