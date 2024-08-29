using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList
{
    public class GetPortfoliosListQueryHandler : IRequestHandler<GetPortfoliosListQuery, List<PortfolioListVm>>
    {
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public GetPortfoliosListQueryHandler(IAsyncRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<List<PortfolioListVm>> Handle(GetPortfoliosListQuery request, CancellationToken cancellationToken)
        {
            var allPortfolios = (await _portfolioRepository.ListAllAsync())
                                .OrderBy(p => p.Name)  // Opcional, ordena os Portfolios por Nome
                                .ToList();

            return _mapper.Map<List<PortfolioListVm>>(allPortfolios);
        }
    }

}
