using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset
{
    public class CreateAssetCommandHandler : IRequestHandler<CreateAssetCommand, Guid>
    {
        private readonly IAsyncRepository<Asset> _assetRepository;
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;
        private readonly IAsyncRepository<Transaction> _transactionRepository;
        private readonly IMapper _mapper;

        public CreateAssetCommandHandler(IAsyncRepository<Asset> assetRepository, IAsyncRepository<Transaction> transactionRepository, IMapper mapper, IAsyncRepository<Portfolio> portfolioRepository)
        {
            _assetRepository = assetRepository;
            _portfolioRepository = portfolioRepository;
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            await new CreateAssetCommandValidator(_portfolioRepository).ValidateAndThrowAsync(request, cancellationToken);

            // Definir o preço inicial com base no tipo de ativo
            decimal initialPrice = request.AssetType switch
            {
                AssetType.Stocks => 100.00m,
                AssetType.Bonds => 1000.00m,
                AssetType.Cryptocurrencies => 332635.00m,
                _ => throw new InvalidOperationException("Tipo de ativo inválido.")
            };

            // Criar o asset
            var asset = _mapper.Map<Asset>(request);
            asset.AssetId = Guid.NewGuid(); // Criar o ID do asset
            asset.Status = "A"; // Definir o status como 'A' ao criar

            await _assetRepository.AddAsync(asset);

            // Criar a transação de compra automaticamente
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AssetId = asset.AssetId,
                UserId = asset.UserId,
                PortfolioId = request.PortfolioId,
                TransactionType = TransactionType.Buy,
                Quantity = 1, // Quantidade padrão, pode ser ajustada
                Price = initialPrice,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepository.AddAsync(transaction);

            return asset.AssetId;
        }
    }
}
