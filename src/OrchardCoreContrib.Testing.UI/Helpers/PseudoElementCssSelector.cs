using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for a specified pseudo element and optional selector.
    /// </summary>
    /// <param name="pseudoElement">The pseudo element.</param>
    /// <param name="selector">The optional selector.</param>
    /// <remarks>
    /// <code>
    /// ::marker {
    ///     color: red;
    /// }
    /// p::first-line {
    ///     color: #ff0000;
    ///     font-variant: small-caps;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoElement(string pseudoElement, string selector = null)
    {
        Guard.ArgumentNotNullOrEmpty(pseudoElement, nameof(pseudoElement));

        return selector is null
            ? $"::{pseudoElement}"
            : $"{selector}::{pseudoElement}";
    }
}
