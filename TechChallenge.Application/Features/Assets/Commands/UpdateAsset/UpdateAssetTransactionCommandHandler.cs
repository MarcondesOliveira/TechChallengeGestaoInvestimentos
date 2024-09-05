using AutoMapper;
using FluentValidation;
using MediatR;
using TechChallengeGestaoInvestimentos.Application.Exceptions;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

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
            var validator = new UpdateAssetTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var asset = await _assetRepository.GetByIdAsync(request.AssetId);
            if (asset == null || asset.Status == "I")
            {
                throw new NotFoundException(nameof(Asset), request.AssetId);
            }

            request.TransactionType = TransactionType.Sale;
            request.Quantity = 2;

            asset.Status = "I";
            await _assetRepository.UpdateAsync(asset);

            var transaction = _mapper.Map<Transaction>(request);
            await _transactionRepository.AddAsync(transaction);
        }
    }
}
