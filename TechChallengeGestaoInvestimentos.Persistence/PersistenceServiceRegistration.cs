using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallengeGestaoInvestimentos.Domain.Interfaces.Persistence;
using TechChallengeGestaoInvestimentos.Persistence.Repositories;

namespace TechChallengeGestaoInvestimentos.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TechChallengeGestaoInvestimentosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }
    }
}
