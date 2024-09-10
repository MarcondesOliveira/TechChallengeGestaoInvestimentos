using TechChallengeGestaoInvestimentos.Application.Responses;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandResponse : BaseResponse
    {
        public CreatePortfolioCommandResponse() : base()
        {

        }

        public CreatePortfolioDto Portfolio { get; set; } = default!;
        public Guid PortfolioId { get; set; }
    }
}
