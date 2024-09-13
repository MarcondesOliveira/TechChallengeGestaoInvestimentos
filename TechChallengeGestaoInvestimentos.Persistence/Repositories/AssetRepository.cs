using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Persistence.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        public AssetRepository(TechChallengeGestaoInvestimentosDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsAssetNameAndDateUnique(string name, DateTime assetDate)
        {
            var matches = _dbContext.Assets.Any(e => e.Name.Equals(name) && e.Date.Date.Equals(assetDate.Date));
            return Task.FromResult(matches);
        }
    }
}
