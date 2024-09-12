using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using TechChallengeGestaoInvestimentos.App.Auth;
using TechChallengeGestaoInvestimentos.App.Interfaces;

namespace TechChallengeGestaoInvestimentos.App.Components.Pages
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((CookieAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected async void Logout()
        {
            await AuthenticationService.Logout();
            NavigationManager.NavigateTo("/", true);

        }
    }
}
