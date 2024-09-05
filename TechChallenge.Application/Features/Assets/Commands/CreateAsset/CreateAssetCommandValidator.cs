using FluentValidation;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset
{
    public class CreateAssetCommandValidator : AbstractValidator<CreateAssetCommand>
    {
        private readonly IAsyncRepository<Portfolio> _portfolioRepository;

        public CreateAssetCommandValidator(IAsyncRepository<Portfolio> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;

            RuleFor(x => x.PortfolioId)
                .NotEmpty().WithMessage("O ID do portfólio é obrigatório.")
                .MustAsync(ValidatePortfolioExistsAndActive).WithMessage("O portfólio está inativo ou não existe.");

            RuleFor(x => x.AssetType)
                .IsInEnum().WithMessage("Tipo de ativo inválido.");
        }

        private async Task<bool> ValidatePortfolioExistsAndActive(Guid portfolioId, CancellationToken cancellationToken)
        {
            var portfolio = await _portfolioRepository.GetByIdAsync(portfolioId);
            return portfolio != null && portfolio.Status == "A";
        }
    }
}
