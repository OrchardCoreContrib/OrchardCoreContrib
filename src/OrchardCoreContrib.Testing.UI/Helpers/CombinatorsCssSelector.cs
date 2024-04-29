using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for all elements that are descendants of a specified element.
    /// Therse are some examples:
    /// <code>
    /// div p {
    ///     background-color: yellow;
    /// }
    /// div > p {
    ///     background-color: yellow;
    /// }
    /// </code>
    /// </summary>
    /// <param name="descendantElement">The descendant element name.</param>
    /// <param name="childElement">The child element name.</param>
    /// <param name="direct">Whether the element is direct descendant. Defaults <c>true</c>.</param>
    public static string Descendant(string descendantElement, string childElement, bool direct = false)
    {
        Guard.ArgumentNotNullOrEmpty(descendantElement, nameof(descendantElement));
        Guard.ArgumentNotNullOrEmpty(childElement, nameof(childElement));

        return string.Concat(descendantElement, direct ? " > " : " ", childElement);
    }

    /// <summary>
    /// Generates a CSS selector for selects all elements that are next siblings of a specified element.
    /// </summary>
    /// <param name="siblingElementName">The sibling element name.</param>
    /// <param name="elementName">The element name.</param>
    /// <param name="adjacent">Whether the element immediately following or not. Defaults <c>false</c>.</param>
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
    public static string Sibling(string siblingElementName, string elementName, bool adjacent = false)
    {
        Guard.ArgumentNotNullOrEmpty(siblingElementName, nameof(siblingElementName));
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));

        return string.Concat(siblingElementName, adjacent ? " + " : " ~ " , elementName);
    }
}
