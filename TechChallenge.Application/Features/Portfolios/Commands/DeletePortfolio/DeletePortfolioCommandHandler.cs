using MediatR;
using TechChallengeGestaoInvestimentos.Application.Exceptions;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand>
    {
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;
        private readonly IAsyncRepository<Asset> _assetRepository;

        public DeletePortfolioCommandHandler(IAsyncRepository<Portfolio> portfolioRepository, IAsyncRepository<Asset> assetRepository)
        {
            _portfolioRepository = portfolioRepository;
            _assetRepository = assetRepository;
        }

        public async Task Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(request.PortfolioId);

            if (portfolio == null)
            {
                throw new NotFoundException(nameof(Portfolio), request.PortfolioId);
            }

            // Verificar se existe algum Asset com Status "A" (Ativo) associado ao Portfolio
            var hasActiveAssets = await _assetRepository.AnyAsync(a => a.PortfolioId == request.PortfolioId && a.Status == "A");

            if (hasActiveAssets)
            {
                throw new InvalidOperationException("O portfolio não pode ser deletado porque ainda possui ativos.");
            }

            // Marcar o portfolio como inativo
            portfolio.Status = "I";
            await _portfolioRepository.UpdateAsync(portfolio);
        }
    }

}
