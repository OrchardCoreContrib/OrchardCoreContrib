using Fluid;
using Microsoft.Extensions.Options;
using OrchardCoreContrib.DisplayManagement.Liquid;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for registering Liquid display management services with an <see cref="IServiceCollection"/>.
/// </summary>
public static class LiquidServiceCollectionExtensions
{
    /// <summary>
    /// Adds Liquid display management services to the specified service collection.
    /// </summary>
    /// <param name="services">The service collection to which the Liquid display management services will be added. Cannot be null.</param>
    /// <returns>The same instance of <see cref="IServiceCollection"/> with Liquid display management services registered.</returns>
    public static IServiceCollection AddLiquidDisplayManagement(this IServiceCollection services)
    {
        services.AddSingleton<IConfigureOptions<TemplateOptions>, TemplateOptionsConfigurations>();

        return services;
    }
}
