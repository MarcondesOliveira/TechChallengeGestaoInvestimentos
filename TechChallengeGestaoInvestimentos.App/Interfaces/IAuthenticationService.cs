using TechChallengeGestaoInvestimentos.App.Services.Base;

namespace TechChallengeGestaoInvestimentos.App.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> Login(string email, string password);
        Task<ApiResponse> Register(string email, string password);
        Task Logout();
    }
}
