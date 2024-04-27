namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for a browser.
/// </summary>
public interface IBrowser
{
    /// <summary>
    /// Gets the browser version.
    /// </summary>
    public string Version { get; }

    /// <summary>
    /// Opens a page with a given URL
    /// </summary>
    /// <param name="url">The page URL to be opened.</param>
    /// <returns>The <see cref="IPage"/></returns>
    public Task<IPage> OpenPageAsync(string url);
}
