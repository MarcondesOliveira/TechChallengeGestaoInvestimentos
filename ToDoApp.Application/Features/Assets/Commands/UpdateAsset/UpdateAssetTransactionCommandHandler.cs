using AutoMapper;
using MediatR;
using TechChallengeGestaoInvestimentos.Application.Exceptions;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset
{
    public class UpdateAssetTransactionCommandHandler : IRequestHandler<UpdateAssetTransactionCommand>
    {
        private readonly IAsyncRepository<Asset> _assetRepository;
        private readonly IAsyncRepository<Transaction> _transactionRepository;
        private readonly IMapper _mapper;

        public UpdateAssetTransactionCommandHandler(IMapper mapper, IAsyncRepository<Asset> assetRepository, IAsyncRepository<Transaction> transactionRepository)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(UpdateAssetTransactionCommand request, CancellationToken cancellationToken)
        {
            // Obter o asset associado
            var asset = await _assetRepository.GetByIdAsync(request.AssetId);
            if (asset == null)
            {
                throw new NotFoundException(nameof(Asset), request.AssetId);
            }

            // Validar se a transação é possível (exemplo: quantidade de venda não excede a quantidade possuída)
            // Isso pode envolver lógica adicional, como calcular o saldo atual de ativos baseado nas transações passadas

            // Criar a transação usando o AutoMapper
            var transaction = _mapper.Map<Transaction>(request);

            // Adicionar a nova transação
            await _transactionRepository.AddAsync(transaction);

            // Não há necessidade de atualizar o asset diretamente, já que a lógica de quantidade não é aplicada aqui.
        }
    }
}
