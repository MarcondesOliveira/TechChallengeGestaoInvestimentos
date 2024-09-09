namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList
{
    public class PortfolioListVm
    {
        public Guid PortfolioId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

}
