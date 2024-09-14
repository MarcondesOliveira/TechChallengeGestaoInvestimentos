using TechChallengeGestaoInvestimentos.AppWebAssembly.Services;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces
{
    public interface IPortfolioDataService
    {
        Task<List<PortfolioViewModel>> GetAllPortfolios();
        //Task<List<PortfolioAssetsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<PortfolioDto>> CreatePortfolio(PortfolioViewModel portfolioViewModel);
    }
}
