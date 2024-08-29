using MediatR;

namespace TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList
{
    public class GetAssetsListQuery : IRequest<List<AssetListVm>>
    {
    }
}
