using AutoMapper;
using Blazored.LocalStorage;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Services
{
    public class PortfolioDataService : BaseDataService, IPortfolioDataService
    {
        private readonly IMapper _mapper;

        public PortfolioDataService(IClient client, ILocalStorageService localStorage, IMapper mapper) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<ApiResponse<PortfolioDto>> CreatePortfolio(PortfolioViewModel portfolioViewModel)
        {
            try
            {
                ApiResponse<PortfolioDto> apiResponse = new ApiResponse<PortfolioDto>();
                CreatePortfolioCommand createPortfolioCommand = _mapper.Map<CreatePortfolioCommand>(portfolioViewModel);
                var createPortfolioCommandResponse = await _client.AddPortfolioAsync(createPortfolioCommand);
                if (createPortfolioCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<PortfolioDto>(createPortfolioCommandResponse.Portfolio);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createPortfolioCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<PortfolioDto>(ex);
            }
        }

        public async Task<List<PortfolioViewModel>> GetAllPortfolios()
        {
            var allPortfolios = await _client.GetAllPortfoliosAsync();
            var mappedPortfolios = _mapper.Map<ICollection<PortfolioViewModel>>(allPortfolios);
            return mappedPortfolios.ToList();
        }
    }
}
