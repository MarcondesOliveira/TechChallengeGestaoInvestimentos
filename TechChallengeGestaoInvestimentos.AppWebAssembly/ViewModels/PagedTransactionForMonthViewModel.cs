namespace TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels
{
    public class PagedTransactionForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<TransactionsForMonthListViewModel>? TransactionsForMonth { get; set; }
    }
}
