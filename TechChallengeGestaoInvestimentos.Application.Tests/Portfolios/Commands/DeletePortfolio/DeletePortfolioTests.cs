using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioTests
    {
        private readonly Mock<IAsyncRepository<Portfolio>> _mockPortfolioRepository;
        private readonly Mock<IAsyncRepository<Asset>> _mockAssetRepository;
        private readonly DeletePortfolioCommandHandler _handler;

        public DeletePortfolioTests()
        {
            _mockPortfolioRepository = new Mock<IAsyncRepository<Portfolio>>();
            _mockAssetRepository = new Mock<IAsyncRepository<Asset>>();

            _handler = new DeletePortfolioCommandHandler(_mockPortfolioRepository.Object, _mockAssetRepository.Object);
        }

        [Fact]
        public async Task Handle_PortfolioWithActiveAssets_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var portfolio = new Portfolio
            {
                PortfolioId = Guid.NewGuid(),
                Status = "A"
            };

            var command = new DeletePortfolioCommand
            {
                PortfolioId = (Guid)portfolio.PortfolioId
            };

            _mockPortfolioRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(portfolio);

            _mockAssetRepository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Asset, bool>>>()))
                .ReturnsAsync(true); // Simula que o portfolio tem ativos com Status "A"

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));

            _mockPortfolioRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _mockAssetRepository.Verify(repo => repo.AnyAsync(It.IsAny<Expression<Func<Asset, bool>>>()), Times.Once);
            _mockPortfolioRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Portfolio>()), Times.Never);
        }

        [Fact]
        public async Task Handle_ValidRequest_ShouldSucceedAndMarkPortfolioAsInactive()
        {
            // Arrange
            var portfolio = new Portfolio
            {
                PortfolioId = Guid.NewGuid(),
                Status = "A"
            };

            var command = new DeletePortfolioCommand
            {
                PortfolioId = (Guid)portfolio.PortfolioId
            };

            _mockPortfolioRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(portfolio);

            _mockAssetRepository.Setup(repo => repo.AnyAsync(It.IsAny<Expression<Func<Asset, bool>>>()))
                .ReturnsAsync(false); // Simula que o portfolio não tem ativos com Status "A"

            _mockPortfolioRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Portfolio>()))
                .Returns(Task.CompletedTask);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            portfolio.Status.Should().Be("I");
            _mockPortfolioRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            _mockAssetRepository.Verify(repo => repo.AnyAsync(It.IsAny<Expression<Func<Asset, bool>>>()), Times.Once);
            _mockPortfolioRepository.Verify(repo => repo.UpdateAsync(It.IsAny<Portfolio>()), Times.Once);
        }
    }
}
