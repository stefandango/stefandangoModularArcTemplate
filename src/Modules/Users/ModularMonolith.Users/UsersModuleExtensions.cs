using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace ModularMonolith.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUserModuleServices(this IServiceCollection services,
        ConfigurationManager config, ILogger logger, List<Assembly> mediatRAssemblies)
    {
        string? connectionString = config.GetConnectionString("UsersConnectionString");
        services.AddDbContext<UsersDbContext>(config 
            => config.UseSqlServer(connectionString));
        

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<UsersDbContext>();
        
        mediatRAssemblies.Add(typeof(UsersModuleExtensions).Assembly);
        
        logger.Information("{Module} module service registered", "Users");
        return services;
    }
}