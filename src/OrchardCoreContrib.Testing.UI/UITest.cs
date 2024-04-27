using Microsoft.Playwright;
using OrchardCoreContrib.Testing.UI.Infrastructure;
using Xunit;
using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a UI testing class that extends <see cref="UITestBase{TStartup}"/>.
/// </summary>
/// <typeparam name="TStartup">The startup class type that will be used as entry point.</typeparam>
public class UITest<TStartup>() :
    UITestBase<TStartup>(new WebApplicationFactoryFixture<TStartup>()),
    IAsyncLifetime where TStartup : class
{
    private IPlaywright _playwright;
    private PlaywrightBrowser _browser;

    /// <summary>
    /// Gets the browser instance to be used during the test.
    /// </summary>
    public IBrowser Browser { get; private set; }

    /// <inheritdoc/>
    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        _browser = await _playwright.Chromium.LaunchAsync();

        Browser = new Browser(_browser);
    }

    /// <inheritdoc/>
    public async Task DisposeAsync()
    {
        _playwright.Dispose();
        
        await _browser.DisposeAsync();
    }
}
