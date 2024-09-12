using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using TechChallengeGestaoInvestimentos.Domain.Common;
using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Domain.Entities
{
    public class Asset //: Entity
    {
        public Guid AssetId { get; set; }
        public AssetType AssetType { get; set; }
        public string? Name { get; set; }
        public Code Code { get; set; }
        public string Status { get; set; } = "A";
        public Guid? PortfolioId { get; set; } 
        public Guid UserId { get; set; }
        public virtual Portfolio? Portfolio { get; set; }
    }
}
