namespace TechChallengeGestaoInvestimentos.App.ViewModels
{
    public class AssetNestedViewModel
    {
        public Guid AssetId { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; } = "A";
        public DateTime Date { get; set; }
        public Guid PortfolioId { get; set; }        
    }
}
