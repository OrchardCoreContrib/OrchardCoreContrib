namespace OrchardCoreContrib.Settings;

/// <summary>
/// Defines a contract for accessing global application settings.
/// </summary>
public interface IGlobalSettingsAccessor
{
    /// <summary>
    /// Retrieves the application settings of the specified type.
    /// </summary>
    /// <typeparam name="TSettings">The type of settings to retrieve.</typeparam>
    /// <returns>A task contains an instance of the requested
    /// settings type.</returns>
    Task<TSettings> GetSettingsAsync<TSettings>() where TSettings : new();
}
