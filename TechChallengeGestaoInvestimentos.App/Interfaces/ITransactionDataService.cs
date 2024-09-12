using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Interfaces
{
    public interface ITransactionDataService
    {
        Task<PagedTransactionForMonthViewModel> GetPagedTransactionForMonth(DateTime date, int page, int size);
    }
}
