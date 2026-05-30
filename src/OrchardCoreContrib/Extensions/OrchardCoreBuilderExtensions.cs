using OrchardCoreContrib;
using OrchardCoreContrib.Avatars;
using OrchardCoreContrib.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for adding OrchardCoreContrib services to the dependency injection container.
/// </summary>
public static class OrchardCoreBuilderExtensions
{
    /// <summary>
    /// Adds the default services for OrchardCoreContrib to the dependency injection container.
    /// </summary>
    /// <param name="builder">The <see cref="OrchardCoreBuilder"/> to add services to.</param>
    /// <returns>The <see cref="OrchardCoreBuilder"/> instance.</returns>
    public static OrchardCoreBuilder AddOrchardCoreContrib(this OrchardCoreBuilder builder)
    {
        Guard.ArgumentNotNull(builder);

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
