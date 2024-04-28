using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Provides an implementation of <see cref="IPlaywrightBrowserAccessor"/> based on the current execution context.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="PlaywrightBrowserAccessor"/>.
/// <paramref name="playwrightBrowser">The <see cref="PlaywrightBrowser"/></paramref>
/// </remarks>
public class PlaywrightBrowserAccessor(PlaywrightBrowser playwrightBrowser) : IPlaywrightBrowserAccessor
{
    /// <inheritdoc/>
    public PlaywrightBrowser PlaywrightBrowser { init; get; } = playwrightBrowser;
}
