using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechChallengeGestaoInvestimentos.Identity.Models;

namespace TechChallengeGestaoInvestimentos.Identity
{
    public class TechChallengeIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public TechChallengeIdentityDbContext()
        {
        }

        public TechChallengeIdentityDbContext(DbContextOptions<TechChallengeIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();
    }    
}
