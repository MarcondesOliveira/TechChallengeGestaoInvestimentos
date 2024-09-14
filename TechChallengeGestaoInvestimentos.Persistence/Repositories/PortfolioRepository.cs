using Microsoft.EntityFrameworkCore;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Persistence.Repositories
{
    public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(TechChallengeGestaoInvestimentosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Portfolio>> GetPortfoliosWithAssets(bool includePassedAssets)
        {
            var allPortfolios = await _dbContext.Portfolios.Include(x => x.Assets).ToListAsync();
            if (!includePassedAssets)
            {
                allPortfolios.ForEach(p => p.Assets.ToList().RemoveAll(c => c.Status == "I"));
            }
            return allPortfolios;
        }
    }
}