using MediatR;
using TechChallengeGestaoInvestimentos.Domain.Enum;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset
{
    public class CreateAssetCommand : IRequest<Guid>
    {
        public AssetType AssetType { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public Code Code { get; set; }
        public Guid PortfolioId { get; set; } = default!;
    }
}
