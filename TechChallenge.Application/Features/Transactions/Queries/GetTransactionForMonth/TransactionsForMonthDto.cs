namespace TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth
{
    public class TransactionsForMonthDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
