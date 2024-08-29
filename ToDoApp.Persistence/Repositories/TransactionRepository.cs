using Microsoft.EntityFrameworkCore;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using TechChallengeGestaoInvestimentos.Persistence;

namespace TechChallengeGestaoInvestimentos.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(TechChallengeGestaoInvestimentosDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Transaction>> GetPagedTransactionsForMonth(DateTime date, int page, int size)
        {
            return await _dbContext.Transactions.Where(x => x.TransactionDate.Month == date.Month && x.TransactionDate.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public Task<int> GetTotalCountofTransactionsForMonth(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
