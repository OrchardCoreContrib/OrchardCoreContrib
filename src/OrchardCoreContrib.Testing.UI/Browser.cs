using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a browser.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Browser"/>.
/// </remarks>
/// <param name="playwrightBrowserAccessor">The <see cref="IPlaywrightBrowserAccessor"/>.</param>
/// <param name="type">The <see cref="BrowserType"/>.</param>
/// <param name="headless">Whether to run browser in headless mode.</param>
public class Browser(IPlaywrightBrowserAccessor playwrightBrowserAccessor, BrowserType type, bool headless) : IBrowser
{
    /// <inheritdoc/>
    public PlaywrightBrowser InnerBrowser => playwrightBrowserAccessor.PlaywrightBrowser;

    /// <inheritdoc/>
    public bool Headless => headless;

    /// <inheritdoc/>
    public BrowserType Type => type;

    /// <inheritdoc/>
    public string Version => InnerBrowser.Version;

    /// <inheritdoc/>
    public async Task<IPage> OpenPageAsync(string url)
    {
        var page = await InnerBrowser.NewPageAsync();

        await page.GotoAsync(url);

        return new Page(new PlaywrightPageAccessor(page));
    }
}
