using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Pages
{
    public partial class AssetDetails
    {
        [Inject]
        public IAssetDataService AssetDataService { get; set; }

        [Inject]
        public IPortfolioDataService PortfolioDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public AssetDetailViewModel AssetDetailViewModel { get; set; }
            = new AssetDetailViewModel() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<PortfolioViewModel> Portfolios { get; set; }
            = new ObservableCollection<PortfolioViewModel>();

        public string Message { get; set; }
        public string SelectedPortfolioId { get; set; }

        [Parameter]
        public string AssetId { get; set; }
        private Guid SelectedAssetId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(AssetId, out SelectedAssetId))
            {
                AssetDetailViewModel = await AssetDataService.GetAssetById(SelectedAssetId);
                SelectedPortfolioId = AssetDetailViewModel.PortfolioId.ToString();
            }

            var list = await PortfolioDataService.GetAllPortfolios();
            Portfolios = new ObservableCollection<PortfolioViewModel>(list);
            SelectedPortfolioId = Portfolios.FirstOrDefault().PortfolioId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            AssetDetailViewModel.PortfolioId = Guid.Parse(SelectedPortfolioId);
            ApiResponse<Guid> response;

            if (SelectedAssetId == Guid.Empty)
            {
                response = await AssetDataService.CreateAsset(AssetDetailViewModel);
            }
            else
            {
                response = await AssetDataService.UpdateAsset(AssetDetailViewModel);
            }
            HandleResponse(response);

        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/assetoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/assetoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
