using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ModularMonolith.Module1;

public static class Module1Extensions
{
    public static IServiceCollection AddModule1Services(this IServiceCollection services, ConfigurationManager config)
    {
        string? connectionString = config.GetConnectionString("Module1ConnectionString");
        services.AddDbContext<Module1ObjectDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IModule1ObjectRepository, EfModule1Repository>();
        services.AddScoped<IModule1Service, Module1Service>();
        return services;
    }
}