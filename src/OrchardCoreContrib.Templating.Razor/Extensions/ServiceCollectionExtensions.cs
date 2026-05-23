using OrchardCoreContrib.Templating;
using OrchardCoreContrib.Templating.Razor;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for registering Razor templating services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the required services for Razor templating.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddRazorTemplating(this IServiceCollection services)
    {
        services.AddSingleton<ITemplateEngine, RazorTemplateEngine>();

        return services;
    }
}
