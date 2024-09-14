using Microsoft.AspNetCore.Components;
using TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces;
using TechChallengeGestaoInvestimentos.AppWebAssembly.ViewModels;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Pages
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
        {

        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            if ((await AuthenticationService.Login(LoginViewModel.Email, LoginViewModel.Password)).Success)
            {
                NavigationManager.NavigateTo("/", true);
            }
            else
            {
                Message = "Username/password combination unknown";
            }
        }
    }
}
