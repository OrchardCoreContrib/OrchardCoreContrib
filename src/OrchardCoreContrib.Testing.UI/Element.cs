using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents an element with a <see cref="IPage"/>.
/// </summary>
/// <remarks>The <see cref="Element"/>.</remarks>
/// <param name="locator">The <see cref="ILocator"/>.</param>
public class Element(ILocator locator) : IElement
{
    private readonly Lazy<string> _innerText = new(() => locator.InnerTextAsync().GetAwaiter().GetResult());
    private readonly Lazy<string> _innerHTML = new(() => locator.InnerHTMLAsync().GetAwaiter().GetResult());
    private readonly Lazy<bool> _enabled = new(() => locator.IsEnabledAsync().GetAwaiter().GetResult());
    private readonly Lazy<bool> _visible = new(() => locator.IsVisibleAsync().GetAwaiter().GetResult());

    /// <inheritdoc/>
    public string InnerText => _innerText.Value;

    /// <inheritdoc/>
    public string InnerHtml => _innerHTML.Value;

    /// <inheritdoc/>
    public bool Enabled => _enabled.Value;

    /// <inheritdoc/>
    public bool Visible => _visible.Value;

    /// <inheritdoc/>
    public async Task ClickAsync() => await locator.ClickAsync();

    /// <inheritdoc/>
    public async Task TypeAsync(string text) => await locator.FillAsync(text);
}
