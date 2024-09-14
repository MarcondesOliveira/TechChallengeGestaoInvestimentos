using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechChallengeGestaoInvestimentos.Identity.Models;

namespace TechChallengeGestaoInvestimentos.Identity
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

            services.AddAuthorizationBuilder();

            services.AddDbContext<TechChallengeIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionStringIdentity")));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<TechChallengeIdentityDbContext>()
                .AddApiEndpoints();
        }
    }
}
