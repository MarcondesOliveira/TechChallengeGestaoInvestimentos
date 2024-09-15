using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces
{
    public interface ITransactionDataService
    {
        Task<PagedTransactionForMonthViewModel> GetPagedTransactionForMonth(DateTime date, int page, int size);
    }
}
