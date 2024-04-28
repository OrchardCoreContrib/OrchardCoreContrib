using PlaywrightPage = Microsoft.Playwright.IPage;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Provides an implementation of <see cref="IPlaywrightPageAccessor"/> based on the current execution context.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="PlaywrightPageAccessor"/>.
/// <paramref name="playwrightPage">The <see cref="PlaywrightPage"/></paramref>
/// </remarks>
public class PlaywrightPageAccessor(PlaywrightPage playwrightPage) : IPlaywrightPageAccessor
{
    /// <inheritdoc/>
    public PlaywrightPage PlaywrightPage { init; get; } = playwrightPage;
}
