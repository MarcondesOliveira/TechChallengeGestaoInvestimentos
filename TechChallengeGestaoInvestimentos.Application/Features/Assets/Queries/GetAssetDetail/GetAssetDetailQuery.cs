using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetDetail
{
    public class GetAssetDetailQuery : IRequest<AssetDetailVm>
    {
        public Guid Id { get; set; }
    }
}
