using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Persistence.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.AssetId);
            //builder.Property(a => a.AssetId).ValueGeneratedOnAdd();
            builder.Property(a => a.AssetType).HasColumnType("varchar(50)").IsRequired();
            builder.Property(a => a.Name).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(a => a.Date).HasColumnType("datetime").IsRequired();
            builder.Property(a => a.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(a => a.PortfolioId).HasColumnType("uniqueidentifier");
            builder.Property(a => a.Status).HasColumnType("varchar(1)").IsRequired().HasDefaultValue("A"); // Status com valor padrão "A"
        }
    }

}
