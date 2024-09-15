using AutoMapper;
using FluentAssertions;
using FluentValidation;
using Moq;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Profiles;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioTests
    {
        private readonly Mock<IAsyncRepository<Portfolio>> _mockPortfolioRepository;
        private readonly IMapper _mockMapper;

        private readonly CreatePortfolioCommandHandler _handler;

        public CreatePortfolioTests()
        {
            _mockPortfolioRepository = new Mock<IAsyncRepository<Portfolio>>();

            // Configurando o AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mockMapper = config.CreateMapper();

            _handler = new CreatePortfolioCommandHandler(_mockPortfolioRepository.Object, _mockMapper);
        }

        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnNewPortfolioId()
        {
            // Arrange
            var command = new CreatePortfolioCommand
            {
                Name = "Cripto",
                Description = "Portfolio de criptomoedas."
            };

            var portfolioId = Guid.NewGuid();

            _mockPortfolioRepository.Setup(repo => repo.AddAsync(It.IsAny<Portfolio>()))
                .ReturnsAsync(new Portfolio { PortfolioId = portfolioId, Name = "Cripto", Status = "A" });

            // Act
            var response = await _handler.Handle(command, CancellationToken.None);

            // Assert
            response.Should().NotBeNull();
            response.PortfolioId.Should().Be(portfolioId);
            _mockPortfolioRepository.Verify(repo => repo.AddAsync(It.IsAny<Portfolio>()), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ShouldThrowValidationException()
        {
            // Arrange
            var command = new CreatePortfolioCommand
            {
                Name = string.Empty, // Inválido: Nome não pode ser vazio
                Description = "Portfolio de criptomoedas."
            };

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));

            _mockPortfolioRepository.Verify(repo => repo.AddAsync(It.IsAny<Portfolio>()), Times.Never);
        }
    }
}
