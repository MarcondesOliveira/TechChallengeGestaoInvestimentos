using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence
{
    public interface IPortfolioRepository : IAsyncRepository<Portfolio>
    {
        Task<List<Portfolio>> GetPortfoliosWithAssets(bool includePassedAssets);
    }
}
