using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets
{
    public class GetPortfoliosListWithAssetsQueryHandler : IRequestHandler<GetPortfoliosListWithAssetsQuery, List<PortfolioAssetListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IPortfolioRepository _portfolioRepository;

        public GetPortfoliosListWithAssetsQueryHandler(IMapper mapper, IPortfolioRepository portfolioRepository)
        {
            _mapper = mapper;
            _portfolioRepository = portfolioRepository;
        }

        public async Task<List<PortfolioAssetListVm>> Handle(GetPortfoliosListWithAssetsQuery request, CancellationToken cancellationToken)
        {
            var list = await _portfolioRepository.GetPortfoliosWithAssets(request.IncludeHistory);

            return _mapper.Map<List<PortfolioAssetListVm>>(list);
        }
    }
}
