namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for a page.
/// </summary>
public interface IPage
{
    /// <summary>
    /// Gets the inner playwright page instance.
    /// </summary>
    public Microsoft.Playwright.IPage InnerPage { get; }

    /// <summary>
    /// Gets the page title.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Gets the page content in HTML format.
    /// </summary>
    public string Content { get; }

    /// <summary>
    /// Navigates to a given URL.
    /// </summary>
    /// <param name="url">The url to be redirected.</param>
    public Task GoToAsync(string url);

    /// <summary>
    /// Finds an element with a page using a given selector.
    /// </summary>
    /// <param name="selector">A selector to be used to look for the element within the page.</param>
    /// <returns></returns>
    public IElement FindElement(string selector);

    public Task ClickAsync(string selector);
}
