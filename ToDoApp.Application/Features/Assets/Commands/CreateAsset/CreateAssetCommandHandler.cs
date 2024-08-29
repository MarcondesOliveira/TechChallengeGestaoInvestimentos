using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Guid>
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IMapper _mapper;

        public CreateAssetCommandHandler(IAssetRepository assetRepository, IMapper mapper)
        {
            _assetRepository = assetRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            var asset = _mapper.Map<Asset>(request);

            asset = await _assetRepository.AddAsync(asset);

            return asset.Id;
        }
    }
}
