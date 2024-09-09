using AutoMapper;
using Blazored.LocalStorage;
using TechChallengeGestaoInvestimentos.App.Interfaces;
using TechChallengeGestaoInvestimentos.App.Services.Base;
using TechChallengeGestaoInvestimentos.App.ViewModels;

namespace TechChallengeGestaoInvestimentos.App.Services
{
    public class PortfolioDataService : BaseDataService, IPortfolioDataService
    {
        private readonly IMapper _mapper;
        public PortfolioDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public Task<ApiResponse<CreatePortfolioCommand>> CreatePortfolio(PortfolioViewModel portfolioViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PortfolioViewModel>> GetAllPortfolios()
        {
            var allPortfolios = await _client.GetAllPortfoliosAsync();
            var mappedPortfolios = _mapper.Map<ICollection<PortfolioViewModel>>(allPortfolios);
            return mappedPortfolios.ToList();
        }
    }
}
