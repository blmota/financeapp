using financeApp.Domain.Repositories;
using financeApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace financeApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        return services;
    }
}