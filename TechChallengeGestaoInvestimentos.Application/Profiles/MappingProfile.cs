using AutoMapper;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.CreateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Commands.UpdateAsset;
using TechChallengeGestaoInvestimentos.Application.Features.Assets.Queries.GetAssetList;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.CreatePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Commands.DeletePortfolio;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfolioList;
using TechChallengeGestaoInvestimentos.Application.Features.Portfolios.Queries.GetPortfoliosListWithAssets;
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
            CreateMap<Asset, AssetListVm>().ReverseMap();
            CreateMap<Asset, CreateAssetCommand>().ReverseMap();
            CreateMap<Asset, PortfolioAssetDto>().ReverseMap();  // Adicionando mapeamento para PortfolioAssetDto

            // Atualização de Asset Transaction
            CreateMap<Asset, UpdateAssetTransactionCommand>().ReverseMap();

            // Mapeamento para Portfolio
            CreateMap<Portfolio, CreatePortfolioCommand>().ReverseMap();
            CreateMap<Portfolio, PortfolioListVm>().ReverseMap();

            CreateMap<Portfolio, PortfolioAssetListVm>()
                .ForMember(dest => dest.Assets, opt => opt.MapFrom(src => src.Assets)) // Mapeando Assets
                .ForMember(dest => dest.PortfolioId, opt => opt.MapFrom(src => src.PortfolioId)); // Certifique-se que CategoryId está mapeado corretamente

            // Novo mapeamento para CreatePortfolioDto
            CreateMap<Portfolio, CreatePortfolioDto>();

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
