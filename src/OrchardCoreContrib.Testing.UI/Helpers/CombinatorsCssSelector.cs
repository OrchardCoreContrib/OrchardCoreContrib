using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for all elements that are descendants of a specified element.
    /// </summary>
    /// <param name="descendantElementName">The descendant element name.</param>
    /// <param name="elementName">The element name.</param>
    /// <remarks>
    /// <code>
    /// div p {
    ///     background-color: yellow;
    /// }
    /// </code>
    /// </remarks>
    public static string Descendant(string descendantElementName, string elementName)
    {
        Guard.ArgumentNotNullOrEmpty(descendantElementName, nameof(descendantElementName));
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));

        return $"{descendantElementName} {elementName}";
    }

    /// <summary>
    /// Generates a CSS selector for all elements that are the children of a specified element.
    /// </summary>
    /// <param name="parentElementName">The parent element name.</param>
    /// <param name="elementName">The element name.</param>
    /// <remarks>
    /// <code>
    /// div > p {
    ///     background-color: yellow;
    /// }
    /// </code>
    /// </remarks>
    public static string Child(string parentElementName, string elementName)
    {
        Guard.ArgumentNotNullOrEmpty(parentElementName, nameof(parentElementName));
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));

        return $"{parentElementName} > {elementName}";
    }

    /// <summary>
    /// Generates a CSS selector for selects all elements that are next siblings of a specified element.
    /// </summary>
    /// <param name="siblingElementName">The sibling element name.</param>
    /// <param name="elementName">The element name.</param>
    /// <param name="adjacent">Whether the element immediately following or not.</param>
    /// <remarks>
    /// <code>
    /// div + p {
    ///     background-color: yellow;
    /// }
    /// </code>
    /// <code>
    /// div > p {
    ///     background-color: yellow;
    /// }
    /// </code>
    /// </remarks>
    public static string Sibling(string siblingElementName, string elementName, bool adjacent)
    {
        Guard.ArgumentNotNullOrEmpty(siblingElementName, nameof(siblingElementName));
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));

        return adjacent
            ? $"{siblingElementName} + {elementName}"
            : $"{siblingElementName} ~ {elementName}";
    }
}
