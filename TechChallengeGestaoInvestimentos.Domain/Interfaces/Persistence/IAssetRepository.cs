using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence
{
    public interface IAssetRepository : IAsyncRepository<Asset>
    {
        Task<bool> IsAssetNameAndDateUnique(string name, DateTime assetDate);
    }
}
