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

        //public async Task<ActionResult<List<AssetListVm>>> GetAllAssets()
        //{
        //    var result = await _mediator.Send(new GetAssetsListQuery());

        //    var activeAssets = result.Where(a => a.Status == "A").ToList();

        //    return Ok(activeAssets);
        //}

        public AssetDetailViewModel AssetDetailViewModel { get; set; }
            = new AssetDetailViewModel() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<PortfolioViewModel> Portfolios { get; set; }
            = new ObservableCollection<PortfolioViewModel>();

        public string Message { get; set; }
        public string SelectedPortfolioId { get; set; }

        [Parameter]
        public string AssetId { get; set; }
        private Guid SelectedAssetId = Guid.Empty;

        
    }
}
