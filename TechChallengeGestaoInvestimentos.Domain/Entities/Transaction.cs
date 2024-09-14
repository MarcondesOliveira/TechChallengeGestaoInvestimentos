using TechChallengeGestaoInvestimentos.Domain.Common;
using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Domain.Entities
{
    public class Transaction //: Entity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; } // Alterado para Guid
        public Guid AssetId { get; set; } // Alterado para Guid
        public TransactionType TransactionType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}