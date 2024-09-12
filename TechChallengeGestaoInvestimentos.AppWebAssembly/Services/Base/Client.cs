namespace TechChallengeGestaoInvestimentos.AppWebAssembly.Services
{
    public partial class Client : IClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return HttpClient;
            }
        }
    }
}
