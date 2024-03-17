using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ModularMonolith.Users.Data;
using ModularMonolith.Users.UseCases;

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
        
        // Add user services
        services.AddScoped<IApplicationUserRepository, EfApplicationUserRepository>();
        
        mediatRAssemblies.Add(typeof(UsersModuleExtensions).Assembly);
        
        logger.Information("{Module} module service registered", "Users");
        return services;
    }
}