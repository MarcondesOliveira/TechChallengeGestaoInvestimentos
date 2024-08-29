using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth
{
    public class GetTransactionsForMonthQuery : IRequest<PagedTransactionsForMonthVm>
    {
        public DateTime Date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
