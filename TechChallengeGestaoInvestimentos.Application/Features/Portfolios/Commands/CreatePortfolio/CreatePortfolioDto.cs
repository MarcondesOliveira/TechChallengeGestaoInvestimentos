namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioDto
    {
        public Guid PortfolioId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
