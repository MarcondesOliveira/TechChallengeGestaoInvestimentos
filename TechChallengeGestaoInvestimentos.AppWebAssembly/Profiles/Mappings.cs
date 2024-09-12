using AutoMapper;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<AssetListVm, AssetListViewModel>().ReverseMap();
            //CreateMap<AssetDetailVm, AssetDetailViewModel>().ReverseMap();

            CreateMap<AssetDetailViewModel, CreateAssetCommand>().ReverseMap();
            CreateMap<AssetDetailViewModel, UpdateAssetTransactionCommand>().ReverseMap();

            CreateMap<PortfolioAssetDto, AssetNestedViewModel>().ReverseMap();

            CreateMap<PortfolioDto, PortfolioViewModel>().ReverseMap();
            CreateMap<PortfolioListVm, PortfolioViewModel>().ReverseMap();
            CreateMap<PortfolioAssetListVm, PortfolioAssetsViewModel>().ReverseMap();
            CreateMap<CreatePortfolioCommand, PortfolioViewModel>().ReverseMap();
            CreateMap<CreatePortfolioDto, PortfolioDto>().ReverseMap();

            CreateMap<PagedTransactionsForMonthVm, PagedTransactionForMonthViewModel>().ReverseMap();
            CreateMap<TransactionsForMonthDto, TransactionsForMonthListViewModel>().ReverseMap();
        }
    }
}
