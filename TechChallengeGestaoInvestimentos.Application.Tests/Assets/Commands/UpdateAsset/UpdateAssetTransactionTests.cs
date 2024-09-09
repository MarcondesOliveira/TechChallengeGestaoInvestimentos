using AutoMapper;
using Moq;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset;
using TechChallengeGestaoInvestimentos.Application.Profiles;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Assets.Commands.UpdateAsset
{
    public class UpdateAssetTransactionTests
    {
        private readonly Mock<IAsyncRepository<Asset>> _mockAssetRepository;
        private readonly Mock<IAsyncRepository<Transaction>> _mockTransactionRepository;
        private readonly IMapper _mapper;
        private readonly UpdateAssetTransactionCommandHandler _handler;

        public UpdateAssetTransactionTests()
        {
            _mockAssetRepository = new Mock<IAsyncRepository<Asset>>();
            _mockTransactionRepository = new Mock<IAsyncRepository<Transaction>>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
            });
            _mapper = configurationProvider.CreateMapper();
                        
            _handler = new UpdateAssetTransactionCommandHandler(_mapper, _mockAssetRepository.Object, _mockTransactionRepository.Object);
        }

        [Fact]
        public async Task Handle_ValidUpdate_ShouldUpdateAssetAndAddTransaction()
        {
            // Arrange
            var assetId = Guid.NewGuid();
            var request = new UpdateAssetTransactionCommand
            {
                AssetId = assetId,
                UserId = Guid.NewGuid(),
                PortfolioId = Guid.NewGuid(),
                TransactionType = TransactionType.Buy,
                Price = 1000m,
                Quantity = 1,
                TransactionDate = DateTime.UtcNow
            };

            // Simular ativo válido
            var asset = new Asset { AssetId = assetId, Status = "A" };
            _mockAssetRepository.Setup(repo => repo.GetByIdAsync(assetId))
                                .ReturnsAsync(asset);

            // Act
            await _handler.Handle(request, CancellationToken.None);

            // Assert
            _mockAssetRepository.Verify(repo => repo.UpdateAsync(It.Is<Asset>(a => a.Status == "I")), Times.Once);
            _mockTransactionRepository.Verify(repo => repo.AddAsync(It.IsAny<Transaction>()), Times.Once);
        }
    }
}
