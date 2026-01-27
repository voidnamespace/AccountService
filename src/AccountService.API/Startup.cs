using AccountService.Infrastructure.Extensions;
namespace AccountService.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(); // регистрирует контроллеры
        services.AddEndpointsApiExplorer();
        services.AddDatabaseConfiguration(Configuration);
    }


    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.MapControllers(); // маршрутизирует
        app.UseHttpsRedirection();

    }


}