using AutoMapper;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Portfolios.Queries.GetPortfolioList
{
    public class GetPortfoliosListTests
    {
        private readonly Mock<IAsyncRepository<Portfolio>> _mockPortfolioRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly GetPortfoliosListQueryHandler _handler;

        public GetPortfoliosListTests()
        {
            _mockPortfolioRepository = new Mock<IAsyncRepository<Portfolio>>();
            _mockMapper = new Mock<IMapper>();

            _handler = new GetPortfoliosListQueryHandler(_mockPortfolioRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfPortfolioListVm()
        {
            // Arrange
            var portfolios = new List<Portfolio>
            {
                new Portfolio { PortfolioId = Guid.NewGuid(), Name = "Cripto" },
                new Portfolio { PortfolioId = Guid.NewGuid(), Name = "Ações" }
            };

            var portfolioListVms = new List<PortfolioListVm>
            {
                new PortfolioListVm { PortfolioId = (Guid)portfolios[0].PortfolioId, Name = "Cripto" },
                new PortfolioListVm { PortfolioId = (Guid)portfolios[1].PortfolioId, Name = "Ações" }
            };

            _mockPortfolioRepository.Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(portfolios); 

            _mockMapper.Setup(m => m.Map<List<PortfolioListVm>>(It.IsAny<List<Portfolio>>()))
                .Returns(portfolioListVms); 

            var query = new GetPortfoliosListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(portfolioListVms); 
            _mockPortfolioRepository.Verify(repo => repo.ListAllAsync(), Times.Once);
            _mockMapper.Verify(m => m.Map<List<PortfolioListVm>>(It.IsAny<List<Portfolio>>()), Times.Once);
        }

        [Fact]
        public async Task Handle_EmptyList_ShouldReturnEmptyList()
        {
            // Arrange
            _mockPortfolioRepository.Setup(repo => repo.ListAllAsync())
                .ReturnsAsync(new List<Portfolio>()); 

            _mockMapper.Setup(m => m.Map<List<PortfolioListVm>>(It.IsAny<List<Portfolio>>()))
                .Returns(new List<PortfolioListVm>()); 

            var query = new GetPortfoliosListQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEmpty(); 
            _mockPortfolioRepository.Verify(repo => repo.ListAllAsync(), Times.Once);
            _mockMapper.Verify(m => m.Map<List<PortfolioListVm>>(It.IsAny<List<Portfolio>>()), Times.Once);
        }
    }
}
