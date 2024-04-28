namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a page.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Page"/>.
/// </remarks>
/// <param name="playwrightPageAccessor">The <see cref="IPlaywrightPageAccessor"/>.</param>
public class Page(IPlaywrightPageAccessor playwrightPageAccessor) : IPage
{
    private readonly Lazy<string> _title = new(() => playwrightPageAccessor.PlaywrightPage.TitleAsync().GetAwaiter().GetResult());
    private readonly Lazy<string> _content = new(() => playwrightPageAccessor.PlaywrightPage.ContentAsync().GetAwaiter().GetResult());

    /// <inheritdoc/>
    public Microsoft.Playwright.IPage InnerPage => playwrightPageAccessor.PlaywrightPage;

    /// <inheritdoc/>
    public string Title => _title.Value;

    /// <inheritdoc/>
    public string Content => _content.Value;

    /// <inheritdoc/>
    public async Task GoToAsync(string url) => await InnerPage.GotoAsync(url);

    /// <inheritdoc/>
    public IElement FindElement(string selector)
    {
        var locator = InnerPage.Locator(selector);

        return new Element(locator);
    }

    public async Task ClickAsync(string selector) => await FindElement(selector).ClickAsync();
}
