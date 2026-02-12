using AccountService.Application.Interfaces;
using AccountService.Infrastructure.Extensions;
using AuthService.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDatabaseConfiguration(configuration);
        services.AddRepositories();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
