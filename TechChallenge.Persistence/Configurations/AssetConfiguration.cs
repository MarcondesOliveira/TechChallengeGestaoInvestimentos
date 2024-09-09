using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Persistence.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.AssetType).HasColumnType("varchar(50)").IsRequired();
            builder.Property(a => a.Name).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(a => a.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(a => a.PortfolioId).HasColumnType("uniqueidentifier").IsRequired(false);
            builder.Property(a => a.Status).HasColumnType("varchar(1)").IsRequired().HasDefaultValue("A"); // Status com valor padrão "A"

            builder.HasOne(a => a.User)
                .WithMany(u => u.Assets)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Portfolio)
                .WithMany(p => p.Assets)
                .HasForeignKey(a => a.PortfolioId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}