using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for all elements with a specified pseudo element.
    /// </summary>
    /// <param name="pseudoElement">The pseudo element.</param>
    /// <remarks>
    /// <code>
    /// ::marker {
    ///     color: red;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoElement(string pseudoElement)
    {
        Guard.ArgumentNotNullOrEmpty(pseudoElement, nameof(pseudoElement));

        return $"::{pseudoElement}";
    }

    /// <summary>
    /// Generates a CSS selector for a specified selector and pseudo element.
    /// </summary>
    /// <param name="selector">The selector.</param>
    /// <param name="pseudoElement">The pseudo element.</param>
    /// <remarks>
    /// <code>
    /// p::first-line {
    ///     color: #ff0000;
    ///     font-variant: small-caps;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoElement(string selector, string pseudoElement)
    {
        Guard.ArgumentNotNullOrEmpty(selector, nameof(selector));
        Guard.ArgumentNotNullOrEmpty(pseudoElement, nameof(pseudoElement));

        return $"{selector}::{pseudoElement}";
    }
}
