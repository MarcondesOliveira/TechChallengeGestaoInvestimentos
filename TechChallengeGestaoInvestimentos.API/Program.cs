using TechChallengeGestaoInvestimentos.API;

var builder = WebApplication.CreateBuilder(args);

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

//app.UseSerilogRequestLogging();

//await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }