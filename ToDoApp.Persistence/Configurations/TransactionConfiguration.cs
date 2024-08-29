using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PortfolioId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(t => t.AssetId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(t => t.TransactionType).HasColumnType("varchar(10)").IsRequired();
            builder.Property(t => t.Quantity).HasColumnType("int").IsRequired();
            builder.Property(t => t.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(t => t.TransactionDate).HasColumnType("datetime").IsRequired();

            builder.HasOne(t => t.Portfolio)
                .WithMany(p => p.Transactions)
                .HasForeignKey(t => t.PortfolioId);

            builder.HasOne(t => t.Asset)
                .WithMany()
                .HasForeignKey(t => t.AssetId);
        }
    }
}