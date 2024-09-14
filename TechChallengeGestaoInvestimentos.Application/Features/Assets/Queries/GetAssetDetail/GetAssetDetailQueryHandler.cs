using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetDetail
{
    public class GetAssetDetailQueryHandler : IRequestHandler<GetAssetDetailQuery, AssetDetailVm>
    {
        private readonly IAsyncRepository<Asset> _assetRepository;
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;
        private readonly IMapper _mapper;

        public GetAssetDetailQueryHandler(IAsyncRepository<Asset> assetRepository, IAsyncRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public async Task<AssetDetailVm> Handle(GetAssetDetailQuery request, CancellationToken cancellationToken)
        {
            var asset = await _assetRepository.GetByIdAsync(request.Id);
            var assetDetailDto = _mapper.Map<AssetDetailVm>(asset);

            var portfolio = await _portfolioRepository.GetByIdAsync(asset.PortfolioId);

            assetDetailDto.Portfolio = _mapper.Map<PortfolioDto>(portfolio);

            return assetDetailDto;
        }
    }
}
