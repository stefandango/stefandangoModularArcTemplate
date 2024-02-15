using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolith.Module1;

public static class Module1Extensions
{
    public static IServiceCollection AddModule1Services(this IServiceCollection services)
    {
        services.AddScoped<IModule1Service, Module1Service>();
        return services;
    }
}