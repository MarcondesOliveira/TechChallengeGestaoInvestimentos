using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommand : IRequest
    {
        public Guid PortfolioId { get; set; }
    }
}
