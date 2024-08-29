using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence
{
    public interface ITransactionRepository : IAsyncRepository<Transaction>
    {
        Task<List<Transaction>> GetPagedTransactionsForMonth(DateTime date, int page, int size);
        Task<int> GetTotalCountofTransactionsForMonth(DateTime date);
    }
}
