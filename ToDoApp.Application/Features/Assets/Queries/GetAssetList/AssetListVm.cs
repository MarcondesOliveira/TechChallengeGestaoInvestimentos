namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList
{
    public class AssetListVm
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Status { get; set; } = "A";
    }

}
