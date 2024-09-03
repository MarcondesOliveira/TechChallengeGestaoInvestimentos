using MediatR;
using TechChallengeGestaoInvestimentos.Application.Exceptions;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio
{
    public class DeletePortfolioCommandHandler : IRequestHandler<DeletePortfolioCommand>
    {
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;

        public DeletePortfolioCommandHandler(IAsyncRepository<Portfolio> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task Handle(DeletePortfolioCommand request, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(request.PortfolioId);

            if (portfolio == null)
            {
                throw new NotFoundException(nameof(Portfolio), request.PortfolioId);
            }

            // Verificar se existe algum Asset com Status "A" (Ativo) associado ao Portfolio
            if (portfolio.Assets != null && portfolio.Assets.Any(a => a.Status == "A"))
            {
                throw new InvalidOperationException("O portfolio não pode ser deletado porque ainda possui ativos.");
            }

            // Marcar o portfolio como inativo
            portfolio.Status = "I";
            await _portfolioRepository.UpdateAsync(portfolio);
        }
    }

}
