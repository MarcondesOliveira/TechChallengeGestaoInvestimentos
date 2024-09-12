namespace TechChallengeGestaoInvestimentos.App.ViewModels
{
    public class PortfolioAssetsViewModel
    {
        public Guid PortfolioId{ get; set; }
        public string Name { get; set; }
        public ICollection<AssetNestedViewModel>? Assets { get; set; }
    }
}
