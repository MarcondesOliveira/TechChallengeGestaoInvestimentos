using AutoMapper;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Commands.CreateTransaction;
using TechChallengeGestaoInvestimentos.Domain.Entities;

namespace TechChallengeGestaoInvestimentos.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento para Asset
            CreateMap<Asset, AssetListVm>().ReverseMap();
            CreateMap<Asset, CreateAssetCommand>().ReverseMap();

            // Mapeamento para Portfolio
            CreateMap<Portfolio, CreatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, PortfolioListVm>().ReverseMap();

            // Mapeamento para Transaction
            CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();
        }
    }
}
