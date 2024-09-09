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
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasKey(p => p.PortfolioId);
            //builder.Property(p => p.UserId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(p => p.Status).HasColumnType("varchar(1)").IsRequired().HasDefaultValue("A");

            //// Ajuste da relação com IdentityUser
            //builder.HasOne<IdentityUser>() // Relaciona com o IdentityUser
            //    .WithMany() // Sem a necessidade de mapear a coleção no IdentityUser
            //                //.HasForeignKey(p => p.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(p => p.Assets)
            //    .WithOne(a => a.Portfolio)
            //    .HasForeignKey(a => a.PortfolioId);

            //builder.HasMany(p => p.Transactions)
            //    .WithOne(t => t.Portfolio)
            //    .HasForeignKey(t => t.PortfolioId);
        }
    }

}
