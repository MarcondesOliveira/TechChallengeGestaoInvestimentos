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
        public Guid? PortfolioId { get; set; } // Alterado para Guid e nullable
        //public Portfolio? Portfolio { get; set; }
        //public Guid UserId { get; set; } // Alterado para Guid
        //public virtual IdentityUser<Guid> User { get; set; }

        // Add the following attribute to disable cascade delete
        //[ForeignKey("PortfolioId")]
        //[InverseProperty("Assets")]
        public virtual Portfolio? Portfolio { get; set; }
    }
}
