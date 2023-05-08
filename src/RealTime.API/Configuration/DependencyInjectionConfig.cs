using RealTime.API.Application.Events;

namespace RealTime.API.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection AddDependencyConfiguration(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddScoped<IEventEmitter, EventEmitter>();

        return services;
    }
}
