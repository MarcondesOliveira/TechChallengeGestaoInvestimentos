﻿using Microsoft.AspNetCore.Components;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Pages
{
    public partial class AddPortfolio
    {
        [Inject]
        public IPortfolioDataService PortfolioDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public PortfolioViewModel PortfolioViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            PortfolioViewModel = new PortfolioViewModel();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await PortfolioDataService.CreatePortfolio(PortfolioViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<PortfolioDto> response)
        {
            if (response.Success)
            {
                Message = "Portfolio added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
