using Fluid;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OrchardCoreContrib.DisplayManagement.Liquid.Values;

namespace OrchardCoreContrib.DisplayManagement.Liquid;

/// <summary>
/// Provides configuration for <see cref="TemplateOptions"/> to inject the current hosting environment into template
/// scope values.
/// </summary>
/// <remarks>This class is typically used in dependency injection scenarios to ensure that templates have access
/// to environment-specific data. The configured environment value can be accessed within templates using the key
/// defined by <see cref="Constants.FluidValueNames.Environment"/>.</remarks>
/// <param name="hostEnvironment">The <see cref="IHostEnvironment"/> representing the application's hosting environment. Used to supply environment
/// information to template options.</param>
public class TemplateOptionsConfigurations(IHostEnvironment hostEnvironment) : IConfigureOptions<TemplateOptions>
{
    /// <inheritdoc/>
    public void Configure(TemplateOptions options)
    {
        options.Scope.SetValue(Constants.FluidValueNames.Environment, new HostingEnvironmentValue(hostEnvironment));
    }
}
