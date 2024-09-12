using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets
{
    public class GetPortfoliosListWithAssetsQuery : IRequest<List<PortfolioAssetListVm>>
    {
        public bool IncludeHistory { get; set; }
    }
}
