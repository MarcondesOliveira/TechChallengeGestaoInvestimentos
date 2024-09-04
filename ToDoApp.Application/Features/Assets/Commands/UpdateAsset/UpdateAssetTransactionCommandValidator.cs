using FluentValidation;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset
{
    public class UpdateAssetTransactionCommandValidator : AbstractValidator<UpdateAssetTransactionCommand>
    {
        public UpdateAssetTransactionCommandValidator()
        {
            RuleFor(x => x.AssetId).NotEmpty().WithMessage("AssetId is required.");
            RuleFor(x => x.PortfolioId).NotEmpty().WithMessage("PortfolioId is required.");
        }
    }
}
