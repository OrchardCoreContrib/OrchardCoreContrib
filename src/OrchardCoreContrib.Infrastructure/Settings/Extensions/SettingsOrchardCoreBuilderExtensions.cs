using OrchardCoreContrib.Settings;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Provides an extension methods for <see cref="OrchardCoreBuilder"/>.
/// </summary>
public static class SettingsOrchardCoreBuilderExtensions
{
    /// <summary>
    /// Adds global settings accessor service.
    /// </summary>
    /// <param name="builder">The <see cref="OrchardCoreBuilder"/>.</param>
    public static OrchardCoreBuilder AddGlobalSettingsAccessor(this OrchardCoreBuilder builder)
    {
        builder.ApplicationServices.AddSingleton<IGlobalSettingsAccessor, GlobalSettingsAccessor>();

        return builder;
    }
}
