using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using OrchardCore.Settings;

namespace OrchardCoreContrib.Settings;

/// <summary>
/// Provides access to global settings from the default tenant.
/// </summary>
/// <param name="shellHost">The shell host used to access tenant-specific services and settings.</param>
public class GlobalSettingsAccessor(IShellHost shellHost) : IGlobalSettingsAccessor
{
    /// <inheritdoc/>
    public async Task<TSettings> GetSettingsAsync<TSettings>() where TSettings : new()
    {
        if (!shellHost.TryGetSettings(ShellSettings.DefaultShellName, out var settings) || settings is null)
        {
            throw new InvalidOperationException("Default tenant not found.");
        }

        var shellScope = await shellHost.GetScopeAsync(settings);

        var siteService = shellScope.ServiceProvider.GetRequiredService<ISiteService>();

        return await siteService.GetSettingsAsync<TSettings>();
    }
}

