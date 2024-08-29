using TechChallengeGestaoInvestimentos.Domain.Common;
using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Domain.Entities
{
    public class Asset : Entity
    {
        public AssetType AssetType { get; set; }
        public string? Name { get; set; }
        public Code Code { get; set; }
        public Guid? PortfolioId { get; set; } // Alterado para Guid e nullable
        public Portfolio? Portfolio { get; set; }
        public Guid UserId { get; set; } // Alterado para Guid
        public virtual User User { get; set; }

    }
}
