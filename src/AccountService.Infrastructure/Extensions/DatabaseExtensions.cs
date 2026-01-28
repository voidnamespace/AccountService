using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AccountService.Infrastructure.Data;

namespace AccountService.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDatabaseConfiguration(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AccountDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("AccountDb")));

        return services;
    }
}
