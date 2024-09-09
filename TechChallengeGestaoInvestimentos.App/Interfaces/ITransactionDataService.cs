using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Interfaces
{
    public interface ITransactionDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
