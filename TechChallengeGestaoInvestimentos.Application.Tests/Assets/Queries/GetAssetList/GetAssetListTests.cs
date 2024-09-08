using AutoMapper;
using FluentAssertions;
using Moq;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList;
using TechChallengeGestaoInvestimentos.Application.Profiles;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Assets.Queries.GetAssetList
{
    public class GetAssetListTests
    {
        private readonly Mock<IAsyncRepository<Asset>> _mockAssetRepository;
        private readonly IMapper _mapper;
        private readonly GetAssetsListQueryHandler _handler;

        public GetAssetListTests()
        {
            _mockAssetRepository = new Mock<IAsyncRepository<Asset>>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
            _handler = new GetAssetsListQueryHandler(_mockAssetRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfAssets()
        {
            // Arrange
            var assets = new List<Asset>
        {
            new Asset { AssetId = Guid.NewGuid(), Name = "Bitcoin", AssetType = AssetType.Cryptocurrencies },
            new Asset { AssetId = Guid.NewGuid(), Name = "Microsoft", AssetType = AssetType.Stocks }
        };

            _mockAssetRepository.Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(assets);

            var query = new GetAssetsListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().HaveCount(2);
            result[0].Name.Should().Be("Bitcoin");
            result[1].Name.Should().Be("Microsoft");
        }

        [Fact]
        public async Task Handle_WhenNoAssets_ShouldReturnEmptyList()
        {
            // Arrange
            _mockAssetRepository.Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(new List<Asset>());

            var query = new GetAssetsListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
