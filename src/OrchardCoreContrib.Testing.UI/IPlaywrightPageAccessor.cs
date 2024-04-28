namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Provides access to a Playwright page.
/// </summary>
public interface IPlaywrightPageAccessor
{
    /// <summary>
    /// Gets the Playwright page instance.
    /// </summary>
    public Microsoft.Playwright.IPage PlaywrightPage { get; }
}
