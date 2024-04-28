using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for all elements with a specified pseudo class.
    /// </summary>
    /// <param name="pseudoClass">The pseudo class.</param>
    /// <remarks>
    /// <code>
    /// :root {
    ///     background: #ff0000;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoClass(string pseudoClass)
    {
        Guard.ArgumentNotNullOrEmpty(pseudoClass, nameof(pseudoClass));

        return $":{pseudoClass}";
    }

    /// <summary>
    /// Generates a CSS selector for a specified selector and pseudo class.
    /// </summary>
    /// <param name="selector">The selector.</param>
    /// <param name="pseudoClass">The pseudo class.</param>
    /// <remarks>
    /// <code>
    /// a:link {
    ///     color: #FF0000;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoClass(string selector, string pseudoClass)
    {
        Guard.ArgumentNotNullOrEmpty(selector, nameof(selector));
        Guard.ArgumentNotNullOrEmpty(pseudoClass, nameof(pseudoClass));

        return $"{selector}:{pseudoClass}";
    }
}
