using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector to select all the elements.
    /// </summary>
    public static string All() => "*";

    /// <summary>
    /// Generates a CSS selector for an element with the specified id.
    /// </summary>
    /// <param name="id">The element identifier.</param>
    public static string Id(string id)
    {
        Guard.ArgumentNotNullOrEmpty(id, nameof(id));

        return $"#{id}";
    }

    /// <summary>
    /// Generates a CSS selector for an element with the specified class name.
    /// </summary>
    /// <param name="name">The element class name.</param>
    public static string ClassName(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return $".{name}";
    }

    /// <summary>
    /// Generates a CSS selector for specified element and class names.
    /// </summary>
    /// <param name="elementName">The element name.</param>
    /// <param name="name">The CSS class name.</param>
    /// <returns></returns>
    public static string ClassName(string elementName, string name)
    {
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return $"{elementName}.{name}";
    }

    /// <summary>
    /// Generates a CSS selector for an element with the specified tag name.
    /// </summary>
    /// <param name="name">The tag name.</param>
    public static string TagName(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return name;
    }

    /// <summary>
    /// Generates a CSS selector for set of element by tag names aka grouping selector.
    /// </summary>
    /// <param name="tagNames">The tag names.</param>
    /// <returns></returns>
    public static string TagName(params string[] tagNames)
    {
        Guard.ArgumentNotNullOrEmpty(tagNames, nameof(tagNames));

        return string.Join(", ", tagNames);
    }
}
