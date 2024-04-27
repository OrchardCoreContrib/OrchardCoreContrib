using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a browser.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Browser"/>.
/// </remarks>
/// <param name="browser">The <see cref="PlaywrightBrowser"/></param>
/// <param name="type">The <see cref="BrowserType"/></param>
public class Browser(PlaywrightBrowser browser, BrowserType type) : IBrowser
{
    /// <inheritdoc/>
    PlaywrightBrowser IBrowser.InnerBrowser => browser;

    /// <inheritdoc/>
    public BrowserType Type => type;

    /// <inheritdoc/>
    public string Version => browser.Version;

    /// <inheritdoc/>
    public async Task<IPage> OpenPageAsync(string url)
    {
        var page = await browser.NewPageAsync();

        await page.GotoAsync(url);

        return new Page(page);
    }
}
