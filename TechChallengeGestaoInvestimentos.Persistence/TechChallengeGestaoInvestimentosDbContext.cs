using Microsoft.EntityFrameworkCore;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces;

namespace TechChallengeGestaoInvestimentos.Persistence
{
    public class TechChallengeGestaoInvestimentosDbContext : DbContext
    {
        private readonly ILoggedInUserService? _loggedInUserService;

        public TechChallengeGestaoInvestimentosDbContext(DbContextOptions<TechChallengeGestaoInvestimentosDbContext> options) : base(options)
        {
        }

        public TechChallengeGestaoInvestimentosDbContext(DbContextOptions<TechChallengeGestaoInvestimentosDbContext> options, ILoggedInUserService loggedInUserService)
            : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TechChallengeGestaoInvestimentosDbContext).Assembly);
        }
    }
}
