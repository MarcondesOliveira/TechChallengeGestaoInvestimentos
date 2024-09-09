using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList
{
    public class GetAssetsListQueryHandler : IRequestHandler<GetAssetsListQuery, List<AssetListVm>>
    {
        private readonly IAsyncRepository<Asset> _assetRepository;
        private readonly IMapper _mapper;

        public GetAssetsListQueryHandler(IAsyncRepository<Asset> assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<List<AssetListVm>> Handle(GetAssetsListQuery request, CancellationToken cancellationToken)
        {
            var allAssets = (await _assetRepository.ListAllAsync()).OrderBy(x => x.Id);

            return _mapper.Map<List<AssetListVm>>(allAssets);
        }
    }
}
