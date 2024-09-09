using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using TechChallengeGestaoInvestimentos.Persistence;

namespace TechChallengeGestaoInvestimentos.Persistence.Repositories
{
    public class PortfolioRepository : BaseRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(TechChallengeGestaoInvestimentosDbContext dbContext) : base(dbContext)
        {
        }
    }
}
