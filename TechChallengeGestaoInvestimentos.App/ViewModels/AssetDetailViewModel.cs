using TechChallengeGestaoInvestimentos.App.Services;

namespace TechChallengeGestaoInvestimentos.App.ViewModels
{
    public class AssetDetailViewModel
    {
        public Guid AssetId { get; set; }
        public AssetType AssetType { get; set; }
        public string? Name { get; set; }
        public Code Code { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; } = default!;
        public PortfolioViewModel Portfolio { get; set; } = default!;
    }
}
