namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for a page.
/// </summary>
public interface IPage
{
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
}
