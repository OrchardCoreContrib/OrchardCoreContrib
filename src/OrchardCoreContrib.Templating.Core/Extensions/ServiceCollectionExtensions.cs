using OrchardCoreContrib.Templating;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides extension methods for registering templating services in an <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers a specific implementation of <see cref="ITemplateEngine"/> and ensures it is registered with the <see cref="TemplateEngineManager"/>.
    /// </summary>
    /// <typeparam name="TTemplateEngine">The type of the template engine to register.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <param name="key">The key of the template engine.</param>
    /// <returns>The <see cref="IServiceCollection"/> with the template engine added.</returns>
    public static IServiceCollection AddTemplateEngine<TTemplateEngine>(this IServiceCollection services, string key) where TTemplateEngine : class, ITemplateEngine
    {
        services.AddKeyedSingleton<ITemplateEngine, TTemplateEngine>(key);
        //services.PostConfigure<TemplateEngineManager>(manager =>
        //{
        //    var engine = services.BuildServiceProvider().GetRequiredService<TTemplateEngine>();

        //    manager.RegisterEngine(engine, key);
        //});

        return services;
    }
}
