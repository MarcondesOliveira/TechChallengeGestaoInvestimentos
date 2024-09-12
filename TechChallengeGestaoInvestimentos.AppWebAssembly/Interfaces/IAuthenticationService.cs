using TechChallengeGestaoInvestimentos.AppWebAssembly.Services.Base;

namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> Login(string email, string password);
        Task<ApiResponse> Register(string email, string password);
        Task Logout();
    }
}
