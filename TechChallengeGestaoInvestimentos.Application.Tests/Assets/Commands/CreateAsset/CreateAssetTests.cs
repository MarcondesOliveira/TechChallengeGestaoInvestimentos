using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Assets.Commands.CreateAsset
{
    public class CreateAssetTests
    {
        private readonly Mock<IAsyncRepository<Asset>> _mockAssetRepository;
        private readonly Mock<IAsyncRepository<Transaction>> _mockTransactionRepository;
        private readonly Mock<IAsyncRepository<Portfolio>> _mockPortfolioRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IHttpContextAccessor> _mockHttpContextAccessor;
        private readonly CreateAssetCommandHandler _handler;

        public CreateAssetTests()
        {
            _mockAssetRepository = new Mock<IAsyncRepository<Asset>>();
            _mockTransactionRepository = new Mock<IAsyncRepository<Transaction>>();
            _mockPortfolioRepository = new Mock<IAsyncRepository<Portfolio>>();
            _mockMapper = new Mock<IMapper>();
            _mockHttpContextAccessor = new Mock<IHttpContextAccessor>();

            _handler = new CreateAssetCommandHandler(
                _mockAssetRepository.Object,
                _mockTransactionRepository.Object,
                _mockMapper.Object,
                _mockPortfolioRepository.Object,
                _mockHttpContextAccessor.Object);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldCreateAssetAndTransaction()
        {
            // Arrange
            var portfolioId = Guid.NewGuid();
            var currentDate = DateTime.UtcNow.AddDays(1); // Data no futuro para satisfazer a validação
            var userId = Guid.NewGuid(); // Simular um UserId válido

            // Configurar o mock do IHttpContextAccessor para retornar o UserId simulado
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString())
            }));
            _mockHttpContextAccessor.Setup(x => x.HttpContext.User).Returns(user);

            var createCommand = new CreateAssetCommand
            {
                Name = "Bitcoin",
                Code = Code.BTC,
                AssetType = AssetType.Stocks,
                PortfolioId = portfolioId,
                Date = currentDate // Adiciona a data válida ao comando
            };

            var mappedAsset = new Asset
            {
                AssetId = Guid.NewGuid(),
                Name = createCommand.Name,
                Code = createCommand.Code,
                UserId = userId, // O UserId agora é obtido do contexto
                PortfolioId = createCommand.PortfolioId,
                Status = "A"
            };

            var validPortfolio = new Portfolio
            {
                PortfolioId = portfolioId,
                Status = "A", // Portfólio ativo
                Name = "Cripto"
            };

            _mockMapper.Setup(m => m.Map<Asset>(It.IsAny<CreateAssetCommand>()))
                .Returns(mappedAsset);

            _mockAssetRepository.Setup(repo => repo.AddAsync(It.IsAny<Asset>()))
                .ReturnsAsync(mappedAsset);

            _mockTransactionRepository.Setup(repo => repo.AddAsync(It.IsAny<Transaction>()))
                .ReturnsAsync((Transaction t) => t);

            _mockPortfolioRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(validPortfolio);

            // Act
            var result = await _handler.Handle(createCommand, CancellationToken.None);

            // Assert
            result.Should().Be(mappedAsset.AssetId);
            _mockMapper.Verify(m => m.Map<Asset>(It.IsAny<CreateAssetCommand>()), Times.Once);
            _mockAssetRepository.Verify(repo => repo.AddAsync(It.IsAny<Asset>()), Times.Once);
            _mockTransactionRepository.Verify(repo => repo.AddAsync(It.IsAny<Transaction>()), Times.Once);
            _mockPortfolioRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidAssetType_ShouldThrowValidationException()
        {
            // Arrange
            var createCommand = new CreateAssetCommand
            {
                Name = "Bitcoin",
                Code = Code.BTC,
                AssetType = (AssetType)99, // Tipo de ativo inválido
                PortfolioId = Guid.NewGuid()
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(createCommand, CancellationToken.None);

            // Assert
            var exception = await act.Should().ThrowAsync<FluentValidation.ValidationException>();

            exception.Which.Errors.Should().ContainSingle(e => e.ErrorMessage == "Tipo de ativo inválido.");
        }
    }
}

