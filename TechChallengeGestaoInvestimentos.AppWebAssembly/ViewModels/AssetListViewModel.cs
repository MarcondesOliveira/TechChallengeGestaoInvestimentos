namespace TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels
{
    public class AssetListViewModel
    {
        public Guid AssetId { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; } = "A";
    }
}
