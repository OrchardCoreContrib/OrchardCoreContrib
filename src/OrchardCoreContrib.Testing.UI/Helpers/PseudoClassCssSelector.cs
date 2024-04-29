using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for a specified pseudo class and optional selctor.
    /// </summary>
    /// <param name="pseudoClass">The pseudo class.</param>
    /// <param name="selector">The optional selector.</param>
    /// <remarks>
    /// <code>
    /// :root {
    ///     background: #ff0000;
    /// }
    /// a:link {
    ///     color: #FF0000;
    /// }
    /// </code>
    /// </remarks>
    public static string PseudoClass(string pseudoClass, string selector = null)
    {
        Guard.ArgumentNotNullOrEmpty(pseudoClass, nameof(pseudoClass));

        return selector is null
            ? $":{pseudoClass}"
            : $"{selector}:{pseudoClass}";
    }
}
