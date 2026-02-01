using AccountService.API.Extensions;
using AccountService.Application;
using AccountService.Application.Commands.CreateAccount;
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
        services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
        services.AddInfrastructure(Configuration);
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerConfiguration();

    }


    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseSwaggerConfiguration();


    }


}