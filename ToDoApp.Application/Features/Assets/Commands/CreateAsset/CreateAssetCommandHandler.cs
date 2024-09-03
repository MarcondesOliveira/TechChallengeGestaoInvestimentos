using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;
//using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

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
            // Verificar se o Portfolio está ativo
            var portfolio = await _portfolioRepository.GetByIdAsync(request.PortfolioId);
            if (portfolio == null || portfolio.Status != "A")
            {
                throw new InvalidOperationException("O ativo não pode ser criado porque o portfólio está inativo ou não existe.");
            }

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
            asset.Id = Guid.NewGuid(); // Criar o ID do asset
            asset.Status = "A"; // Definir o status como 'A' ao criar

            await _assetRepository.AddAsync(asset);

            // Criar a transação de compra automaticamente
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                AssetId = asset.Id,
                PortfolioId = request.PortfolioId,
                TransactionType = TransactionType.Buy,
                Quantity = 1, // Quantidade padrão, pode ser ajustada
                Price = initialPrice,
                TransactionDate = DateTime.UtcNow
            };

            await _transactionRepository.AddAsync(transaction);

            return asset.Id;
        }
    }
}
