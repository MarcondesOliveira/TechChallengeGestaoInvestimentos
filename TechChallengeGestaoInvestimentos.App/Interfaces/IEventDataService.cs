using TechChallengeGestaoInvestimentos.App.Services.Base;
using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Interfaces
{
    public interface IAssetDataService
    {
        Task<List<AssetListViewModel>> GetAllAssets();
        Task<ApiResponse<Guid>> CreateAsset(AssetDetailViewModel assetDetailViewModel);
        Task<ApiResponse<Guid>> UpdateAsset(AssetDetailViewModel assetDetailViewModel);
    }
}
