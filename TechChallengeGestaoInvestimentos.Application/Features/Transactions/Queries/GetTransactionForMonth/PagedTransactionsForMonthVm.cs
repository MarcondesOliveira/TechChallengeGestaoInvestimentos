namespace TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth
{
    public class PagedTransactionsForMonthVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<TransactionsForMonthDto>? TransactionsForMonth { get; set; }
    }
}
