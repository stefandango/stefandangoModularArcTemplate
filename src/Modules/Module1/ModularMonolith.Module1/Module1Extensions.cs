using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Serilog;

using ModularMonolith.Module1.Data;

namespace ModularMonolith.Module1;

public static class Module1Extensions
{
    public static IServiceCollection AddModule1Services(this IServiceCollection services,
        ConfigurationManager config,
        ILogger logger, List<Assembly> mediatRAssemblies)
    {
        string? connectionString = config.GetConnectionString("Module1ConnectionString");
        services.AddDbContext<Module1ObjectDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<IModule1ObjectRepository, EfModule1Repository>();
        services.AddScoped<IModule1Service, Module1Service>();
        
        mediatRAssemblies.Add(typeof(Module1Extensions).Assembly);
        
        logger.Information("{Module} module service registered", "Module1");
        return services;
    }
}