using TechChallengeGestaoInvestimentos.App.Services;
using TechChallengeGestaoInvestimentos.App.Services.Base;
using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Interfaces
{
    public interface IPortfolioDataService
    {
        Task<List<PortfolioViewModel>> GetAllPortfolios();
        //Task<List<PortfolioAssetsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<PortfolioDto>> CreatePortfolio(PortfolioViewModel portfolioViewModel);
    }
}
