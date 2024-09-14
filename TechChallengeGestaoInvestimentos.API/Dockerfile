#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TechChallengeGestaoInvestimentos.API/TechChallengeGestaoInvestimentos.API.csproj", "TechChallengeGestaoInvestimentos.API/"]
COPY ["TechChallengeGestaoInvestimentos.Application/TechChallengeGestaoInvestimentos.Application.csproj", "TechChallengeGestaoInvestimentos.Application/"]
COPY ["TechChallengeGestaoInvestimentos.Domain/TechChallengeGestaoInvestimentos.Domain.csproj", "TechChallengeGestaoInvestimentos.Domain/"]
COPY ["TechChallengeGestaoInvestimentos.Persistence/TechChallengeGestaoInvestimentos.Persistence.csproj", "TechChallengeGestaoInvestimentos.Persistence/"]
COPY ["TechChallengeGestaoInvestimentos.Identity/TechChallengeGestaoInvestimentos.Identity.csproj", "TechChallengeGestaoInvestimentos.Identity/"]
RUN dotnet restore "./TechChallengeGestaoInvestimentos.API/TechChallengeGestaoInvestimentos.API.csproj"
COPY . .
WORKDIR "/src/TechChallengeGestaoInvestimentos.API"
RUN dotnet build "./TechChallengeGestaoInvestimentos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TechChallengeGestaoInvestimentos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TechChallengeGestaoInvestimentos.API.dll"]