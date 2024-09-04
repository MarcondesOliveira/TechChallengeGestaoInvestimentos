using FluentValidation;

namespace TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio
{
    public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
    {
        public CreatePortfolioCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome do portfólio é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do portfólio deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição do portfólio é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição do portfólio deve ter no máximo 500 caracteres.");
        }
    }
}
