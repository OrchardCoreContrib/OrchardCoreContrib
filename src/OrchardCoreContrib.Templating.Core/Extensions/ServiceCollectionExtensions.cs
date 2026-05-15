using OrchardCoreContrib.Templating;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for registering templating services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers the necessary services for templating, including the <see cref="TemplateEngineManager"/> and the default <see cref="ITemplateRenderer"/> implementation.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the templating services added.</returns>
    public static IServiceCollection AddTemplating(this IServiceCollection services)
    {
        services.AddSingleton<TemplateEngineManager>();
        services.AddSingleton<ITemplateEngineFactory>(sp => sp.GetRequiredService<TemplateEngineManager>());
        services.AddSingleton<ITemplateRenderer, DefaultTemplateRenderer>();

        return services;
    }

    /// <summary>
    /// Registers a specific implementation of <see cref="ITemplateEngine"/> and ensures it is registered with the <see cref="TemplateEngineManager"/>.
    /// </summary>
    /// <typeparam name="TTemplateEngine">The type of the template engine to register.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the template engine added.</returns>
    public static IServiceCollection AddTemplateEngine<TTemplateEngine>(this IServiceCollection services) where TTemplateEngine : class, ITemplateEngine
    {
        services.AddSingleton<ITemplateEngine, TTemplateEngine>();
        services.PostConfigure<TemplateEngineManager>(manager =>
        {
            var engine = services.BuildServiceProvider().GetRequiredService<TTemplateEngine>();

            manager.RegisterEngine(engine);
        });

        return services;
    }
}
