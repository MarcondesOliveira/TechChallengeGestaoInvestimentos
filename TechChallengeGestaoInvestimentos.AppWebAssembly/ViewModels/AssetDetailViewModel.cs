//ing TechChallengeGestaoInvestimentos.AppWebAssembly.Services;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels
{
    public class AssetDetailViewModel
    {
        public Guid AssetId { get; set; }
        public string AssetType { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public string Code { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; } = default!;
        public PortfolioViewModel Portfolio { get; set; } = default!;
    }
}
