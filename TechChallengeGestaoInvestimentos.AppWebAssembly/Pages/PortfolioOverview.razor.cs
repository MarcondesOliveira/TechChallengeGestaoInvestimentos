using Microsoft.AspNetCore.Components;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Pages
{
    public partial class PortfolioOverview
    {
        [Inject]
        public IPortfolioDataService PortfolioDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<PortfolioAssetsViewModel> Portfolios { get; set; }

        //protected async override Task OnInitializedAsync()
        //{
        //    Portfolios = await PortfolioDataService.GetAllPortfolios();
        //}

        //protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        //{
        //    if ((bool)args.Value)
        //    {
        //        Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
        //    }
        //    else
        //    {
        //        Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        //    }
        //}
    }
}
