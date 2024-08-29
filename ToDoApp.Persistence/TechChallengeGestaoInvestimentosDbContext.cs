using Microsoft.EntityFrameworkCore;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Persistence
{
    public class TechChallengeGestaoInvestimentosDbContext : DbContext
    {
        public TechChallengeGestaoInvestimentosDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechChallengeGestaoInvestimentosDbContext).Assembly);
        }
    }
}
