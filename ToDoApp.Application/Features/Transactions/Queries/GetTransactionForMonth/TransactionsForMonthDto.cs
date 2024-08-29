namespace TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth
{
    public class TransactionsForMonthDto
    {
        public Guid Id { get; set; }
        public int TransactionTotal { get; set; }
        public DateTime TransactionPlaced { get; set; }
    }
}
