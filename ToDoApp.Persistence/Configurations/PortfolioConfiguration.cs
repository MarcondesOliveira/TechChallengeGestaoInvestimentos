using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Persistence.Configurations
{
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(100)").IsRequired(false);

            builder.HasMany(p => p.Assets)
                .WithOne(a => a.Portfolio)
                .HasForeignKey(a => a.PortfolioId);

            builder.HasMany(p => p.Transactions)
                .WithOne(t => t.Portfolio)
                .HasForeignKey(t => t.PortfolioId);
        }
    }
}