using OrchardCoreContrib.Templating;
using OrchardCoreContrib.Templating.Razor;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRazorTemplating(this IServiceCollection services)
    {
        services.AddSingleton<ITemplateEngine, RazorTemplateEngine>();

        return services;
    }
}
