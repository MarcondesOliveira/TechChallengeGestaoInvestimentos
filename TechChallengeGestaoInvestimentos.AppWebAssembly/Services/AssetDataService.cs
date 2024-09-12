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

        //public async Task<ApiResponse<Guid>> CreateAsset(AssetDetailViewModel assetDetailViewModel)
        //{
        //    try
        //    {
        //        // Mapeando a ViewModel para o CreateAssetCommand
        //        var createAssetCommand = _mapper.Map<CreateAssetCommand>(assetDetailViewModel);
        //        // Usando o cliente gerado pelo NSwag para chamar a API
        //        var newId = await _client.AddAssetAsync(createAssetCommand);

        //        return new ApiResponse<Guid> { Data = newId, Success = true };
        //    }
        //    catch (ApiException ex)
        //    {
        //        return ConvertApiExceptions<Guid>(ex);
        //    }
        //}

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
            // Chamando o método gerado pelo NSwag para obter todos os assets
            var allAssets = await _client.GetAllAssetsAsync();
            // Mapeando os assets retornados para a ViewModel
            var mappedAssets = _mapper.Map<ICollection<AssetListViewModel>>(allAssets);

            return mappedAssets.ToList();
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
