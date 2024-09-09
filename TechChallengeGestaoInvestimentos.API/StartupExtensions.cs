using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TechChallengeGestaoInvestimentos.API.Middleware;
using TechChallengeGestaoInvestimentos.API.Services;
using TechChallengeGestaoInvestimentos.Application;
using TechChallengeGestaoInvestimentos.Domain.Interfaces;
using TechChallengeGestaoInvestimentos.Identity;
using TechChallengeGestaoInvestimentos.Identity.Models;
using TechChallengeGestaoInvestimentos.Persistence;

namespace TechChallengeGestaoInvestimentos.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.MapIdentityApi<ApplicationUser>();

            app.MapPost("/Logout", async (ClaimsPrincipal user, SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return TypedResults.Ok();
            });

            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
    }
}
