namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for page element.
/// </summary>
public interface IElement
{
    /// <summary>
    /// Gets the inner text of the element.
    /// </summary>
    public string InnerText { get; }

    /// <summary>
    /// Gets the inner HTML of the element.
    /// </summary>
    public string InnerHtml { get; }

    /// <summary>
    /// Gets whether the element is enabled.
    /// </summary>
    public bool Enabled { get; }

    /// <summary>
    /// Gets whether the element is visible.
    /// </summary>
    public bool Visible { get; }

    /// <summary>
    /// Writes a given text into an element.
    /// </summary>
    /// <param name="text">A text to be written in the element.</param>
    public Task TypeAsync(string text);

    /// <summary>
    /// Clicks the element.
    /// </summary>
    public Task ClickAsync();
}
