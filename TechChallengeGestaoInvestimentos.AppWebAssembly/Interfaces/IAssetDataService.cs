using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces
{
    public interface IAssetDataService
    {
        Task<List<AssetListViewModel>> GetAllAssets();
        Task<ApiResponse<Guid>> CreateAsset(AssetDetailViewModel assetDetailViewModel);
        Task<ApiResponse<Guid>> UpdateAsset(AssetDetailViewModel assetDetailViewModel);
    }
}
