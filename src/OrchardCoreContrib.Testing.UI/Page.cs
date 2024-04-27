using PlaywrightPage = Microsoft.Playwright.IPage;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a page.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Page"/>.
/// </remarks>
/// <param name="page">The <see cref="PlaywrightPage"/>.</param>
public class Page(PlaywrightPage page) : IPage
{
    private readonly Lazy<string> _title = new(() => page.TitleAsync().GetAwaiter().GetResult());
    private readonly Lazy<string> _content = new(() => page.ContentAsync().GetAwaiter().GetResult());

    /// <inheritdoc/>
    public string Title => _title.Value;

    /// <inheritdoc/>
    public string Content => _content.Value;

    /// <inheritdoc/>
    public async Task GoToAsync(string url) => await page.GotoAsync(url);
}
