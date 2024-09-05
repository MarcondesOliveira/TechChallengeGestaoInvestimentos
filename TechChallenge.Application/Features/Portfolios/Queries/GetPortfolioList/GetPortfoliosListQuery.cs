using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList
{
    public class GetPortfoliosListQuery : IRequest<List<PortfolioListVm>>
    {
    }

}
