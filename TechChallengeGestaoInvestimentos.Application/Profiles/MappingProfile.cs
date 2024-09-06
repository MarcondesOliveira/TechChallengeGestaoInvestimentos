using AutoMapper;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Commands.CreateTransaction;
using TechChallengeGestaoInvestimentos.Application.Features.Transactions.Queries.GetTransactionForMonth;
using TechChallengeGestaoInvestimentos.Domain.Entities;
using TechChallengeGestaoInvestimentos.Domain.Enum;
using Transaction = TechChallengeGestaoInvestimentos.Domain.Entities.Transaction;

namespace TechChallengeGestaoInvestimentos.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeamento para Asset
            CreateMap<Asset, AssetListVm>().ReverseMap();
            CreateMap<Asset, CreateAssetCommand>().ReverseMap();

            // Atualização de Asset Transaction
            CreateMap<Asset, UpdateAssetTransactionCommand>().ReverseMap();

            // Mapeamento para Portfolio
            CreateMap<Portfolio, CreatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, PortfolioListVm>().ReverseMap();

            CreateMap<DeletePortfolioCommand, Portfolio>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "I"));

            // Mapeamento para Transaction
            CreateMap<Transaction, CreateTransactionCommand>().ReverseMap();

            CreateMap<Transaction, TransactionsForMonthDto>();

            CreateMap<UpdateAssetTransactionCommand, Transaction>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.TransactionType == TransactionType.Sale ? 2 : src.Quantity))
                .ReverseMap();
        }
    }
}
