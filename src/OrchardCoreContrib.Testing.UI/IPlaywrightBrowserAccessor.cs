namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Provides access to a Playwright browser.
/// </summary>
public interface IPlaywrightBrowserAccessor
{
    /// <summary>
    /// Gets the Playwright browser instance.
    /// </summary>
    public Microsoft.Playwright.IBrowser PlaywrightBrowser { get; }
}
