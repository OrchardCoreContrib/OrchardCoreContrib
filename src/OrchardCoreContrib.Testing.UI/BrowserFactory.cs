using Microsoft.Playwright;
using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a factory for creating <see cref="IBrowser"/>.
/// </summary>
public static class BrowserFactory
{
    private static readonly PlaywrightBrowser _chromeBrowser = null;
    private static readonly PlaywrightBrowser _edgeBrowser = null;
    private static readonly PlaywrightBrowser _fireFoxBrowser = null;

    /// <summary>
    /// Creates a new instance of <see cref="IBrowser"/> with a given browser type.
    /// </summary>
    /// <param name="playwright">The <see cref="IPlaywright"/>.</param>
    /// <param name="browserType">The browser type in which <see cref="IBrowser"/> will be created.</param>
    /// <returns>An instance of <see cref="IBrowser"/>.</returns>
    /// <exception cref="NotSupportedException"></exception>
    public static async Task<IBrowser> CreateAsync(IPlaywright playwright, BrowserType browserType)
    {
        var browser = browserType switch
        {
            BrowserType.Edge => _edgeBrowser ?? await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "msedge" }),
            BrowserType.Chrome => _chromeBrowser ?? await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions()),
            BrowserType.Firefox => _fireFoxBrowser ?? await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions()),
            _ => throw new NotSupportedException()
        };

        return new Browser(browser, browserType);
    }
}
