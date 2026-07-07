FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["financeApp.Api/financeApp.Api.csproj", "financeApp.Api/"]
COPY ["financeApp.Application/financeApp.Application.csproj", "financeApp.Application/"]
COPY ["financeApp.Domain/financeApp.Domain.csproj", "financeApp.Domain/"]
COPY ["financeApp.Infrastructure/financeApp.Infrastructure.csproj", "financeApp.Infrastructure/"]
RUN dotnet restore "financeApp.Api/financeApp.Api.csproj"
COPY . .
WORKDIR "/src/financeApp.Api"
RUN dotnet build "./financeApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicação
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./financeApp.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Desenvolvimento
FROM build AS dev
WORKDIR /src/financeApp.Api
ENV ASPNETCORE_ENVIRONMENT=Development
CMD ["dotnet", "watch", "run", "--urls=http://0.0.0.0:8080"]

# Produção
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "financeApp.Api.dll"]
