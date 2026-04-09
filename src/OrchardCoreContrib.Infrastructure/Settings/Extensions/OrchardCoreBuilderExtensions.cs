using OrchardCoreContrib.Settings;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides an extension methods for <see cref="OrchardCoreBuilder"/>.
/// </summary>
public static class OrchardCoreBuilderExtensions
{
    /// <summary>
    /// Adds global settings accessor service.
    /// </summary>
    /// <param name="builder">The <see cref="OrchardCoreBuilder"/>.</param>
    public static OrchardCoreBuilder AddGlobalSettingsAccessor(this OrchardCoreBuilder builder)
    {
        //builder.ConfigureServices(services =>
        //    services.AddTransient<IGlobalSettingsAccessor, GlobalSettingsAccessor>());
        builder.ApplicationServices.AddSingleton<IGlobalSettingsAccessor, GlobalSettingsAccessor>();

        return builder;
    }
}
