using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetDetail
{
    public class AssetDetailVm
    {
        public Guid AssetId { get; set; }
        public AssetType AssetType { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Code Code { get; set; }
        public string Status { get; set; }
        public Guid PortfolioId { get; set; }
        public PortfolioDto Portfolio { get; set; }

    }
}
