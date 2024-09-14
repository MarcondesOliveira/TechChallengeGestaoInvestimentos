using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateAssetTransactionCommandHandler(IMapper mapper, IAsyncRepository<Asset> assetRepository, IAsyncRepository<Transaction> transactionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _assetRepository = assetRepository;
            _transactionRepository = transactionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Handle(UpdateAssetTransactionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAssetTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var asset = await _assetRepository.GetByIdAsync(request.AssetId);
            if (asset == null || asset.Status == "I")
            {
                throw new NotFoundException(nameof(Asset), request.AssetId);
            }

            // Obter o UserId do usuário logado
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new UnauthorizedAccessException("Usuário não autenticado.");
            }
            var userId = Guid.Parse(userIdClaim.Value);

            // Atualizar o asset para inativo
            asset.Status = "I";
            await _assetRepository.UpdateAsync(asset);

            // Atualizar os dados da transação para venda
            request.TransactionType = TransactionType.Sale;
            request.Quantity = 2; // Ajustar a quantidade para venda

            // Criar a transação de venda
            var transaction = _mapper.Map<Transaction>(request);
            transaction.UserId = userId; // Definir o UserId do usuário logado
            transaction.TransactionDate = DateTime.UtcNow; // Definir a data da transação

            await _transactionRepository.AddAsync(transaction);
        }
    }
}
