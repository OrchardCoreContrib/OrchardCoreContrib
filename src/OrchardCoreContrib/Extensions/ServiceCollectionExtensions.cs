using OrchardCoreContrib;
using OrchardCoreContrib.Avatars;
using OrchardCoreContrib.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for adding OrchardCoreContrib services to the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds OrchardCoreContrib services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <returns>The <see cref="OrchardCoreBuilder"/> instance.</returns>
    public static OrchardCoreBuilder AddOrchardCoreContrib(this IServiceCollection services)
    {
        Guard.ArgumentNotNull(services);

        var builder = services
            .LastOrDefault(d => d.ServiceType == typeof(OrchardCoreBuilder))?
            .ImplementationInstance as OrchardCoreBuilder;

        builder ??= services.AddOrchardCore();

        AddDefaultServices(builder);

        return builder;
    }

    private static void AddDefaultServices(OrchardCoreBuilder builder)
    {
        var services = builder.ApplicationServices;

        services.AddSingleton<TimeProvider, SystemTimeProvider>();
        services.AddSingleton<IAvatarService, NullAvatarService>();
    }
}
