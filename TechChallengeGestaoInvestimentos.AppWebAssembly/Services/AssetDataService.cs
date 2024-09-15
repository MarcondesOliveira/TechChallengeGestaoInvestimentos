using AutoMapper;
using Blazored.LocalStorage;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Services
{
    public class AssetDataService : BaseDataService, IAssetDataService
    {
        private readonly IMapper _mapper;

        public AssetDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<Guid>> CreateAsset(AssetDetailViewModel assetDetailViewModel)
        {
            try
            {                
                CreateAssetCommand createAssetCommand = _mapper.Map<CreateAssetCommand>(assetDetailViewModel);
                
                var newId = await _client.AddAssetAsync(createAssetCommand);

                return new ApiResponse<Guid> { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }


        public async Task<List<AssetListViewModel>> GetAllAssets()
        {
            var allAssets = await _client.GetAllAssetsAsync();
            var mappedAssets = _mapper.Map<ICollection<AssetListViewModel>>(allAssets);
            return mappedAssets.ToList();
        }

        public async Task<AssetDetailViewModel> GetAssetById(Guid id)
        {
            var selectedAsset = await _client.GetAssetByIdAsync(id);
            var mappedEvent = _mapper.Map<AssetDetailViewModel>(selectedAsset);
            return mappedEvent;
        }

        public async Task<ApiResponse<Guid>> UpdateAsset(AssetDetailViewModel assetDetailViewModel)
        {
            try
            {
                // Mapeando o ViewModel para o comando de atualização
                var updateAssetCommand = _mapper.Map<UpdateAssetTransactionCommand>(assetDetailViewModel);

                // Passando o AssetId e o comando para o método gerado
                await _client.UpdateAssetTransactionAsync(assetDetailViewModel.AssetId, updateAssetCommand, CancellationToken.None);

                return new ApiResponse<Guid> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
