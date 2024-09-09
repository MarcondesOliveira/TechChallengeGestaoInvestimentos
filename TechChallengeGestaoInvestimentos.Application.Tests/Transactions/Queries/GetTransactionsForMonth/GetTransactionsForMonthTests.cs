using AutoMapper;
using FluentAssertions;
using Moq;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth;
using TechChallengeGestaoInvestimentos.Application.Profiles;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Tests.Transactions.Queries.GetTransactionsForMonth
{
    public class GetTransactionsForMonthTests
    {
        private readonly Mock<ITransactionRepository> _mockTransactionRepository;
        private readonly IMapper _mapper;
        private readonly GetTransactionsForMonthQueryHandler _handler;

        public GetTransactionsForMonthTests()
        {
            _mockTransactionRepository = new Mock<ITransactionRepository>();

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            _handler = new GetTransactionsForMonthQueryHandler(_mockTransactionRepository.Object, _mapper);
        }

        [Fact]
        public async Task Handle_ValidRequest_ReturnsPagedTransactionsForMonthVm()
        {
            // Arrange
            var request = new GetTransactionsForMonthQuery
            {
                Date = new DateTime(2024, 9, 1),
                Page = 1,
                Size = 10
            };

            var transactionsList = new List<Transaction>
            {
                new Transaction { Id = Guid.NewGuid(), AssetId = Guid.NewGuid(), Price = 100, Quantity = 1 },
                new Transaction { Id = Guid.NewGuid(), AssetId = Guid.NewGuid(), Price = 150, Quantity = 2 }
            };

            _mockTransactionRepository.Setup(repo => repo.GetPagedTransactionsForMonth(request.Date, request.Page, request.Size))
                                      .ReturnsAsync(transactionsList);

            _mockTransactionRepository.Setup(repo => repo.GetTotalCountofTransactionsForMonth(request.Date))
                                      .ReturnsAsync(2);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(2);
            result.TransactionsForMonth.Count.Should().Be(2);
            result.Page.Should().Be(request.Page);
            result.Size.Should().Be(request.Size);
        }

        [Fact]
        public async Task Handle_EmptyTransactions_ReturnsEmptyPagedTransactionsForMonthVm()
        {
            // Arrange
            var request = new GetTransactionsForMonthQuery
            {
                Date = new DateTime(2024, 9, 1),
                Page = 1,
                Size = 10
            };

            _mockTransactionRepository.Setup(repo => repo.GetPagedTransactionsForMonth(request.Date, request.Page, request.Size))
                                      .ReturnsAsync(new List<Transaction>());

            _mockTransactionRepository.Setup(repo => repo.GetTotalCountofTransactionsForMonth(request.Date))
                                      .ReturnsAsync(0);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(0);
            result.TransactionsForMonth.Should().BeEmpty();
            result.Page.Should().Be(request.Page);
            result.Size.Should().Be(request.Size);
        }

        [Fact]
        public async Task Handle_InvalidPageOrSize_ThrowsArgumentException()
        {
            // Arrange
            var request = new GetTransactionsForMonthQuery
            {
                Date = new DateTime(2024, 9, 1),
                Page = -1, // Página inválida
                Size = 0   // Tamanho inválido
            };

            // Act
            Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
