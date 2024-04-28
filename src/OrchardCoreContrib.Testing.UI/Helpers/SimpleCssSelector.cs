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
    /// <param name="className">The element class name.</param>
    public static string Class(string className)
    {
        Guard.ArgumentNotNullOrEmpty(className, nameof(className));

        return $".{className}";
    }

    /// <summary>
    /// Generates a CSS selector for specified element and class names.
    /// </summary>
    /// <param name="elementName">The element name.</param>
    /// <param name="className">The CSS class name.</param>
    /// <returns></returns>
    public static string Class(string elementName, string className)
    {
        Guard.ArgumentNotNullOrEmpty(elementName, nameof(elementName));
        Guard.ArgumentNotNullOrEmpty(className, nameof(className));

        return $"{elementName}.{className}";
    }

    /// <summary>
    /// Generates a CSS selector for an element with the specified name.
    /// </summary>
    /// <param name="name">The element name.</param>
    public static string Name(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return name;
    }

    /// <summary>
    /// Generates a CSS selector for set of element names aka grouping selector.
    /// </summary>
    /// <param name="elementNames">The element names.</param>
    /// <returns></returns>
    public static string Name(params string[] elementNames)
    {
        Guard.ArgumentNotNullOrEmpty(elementNames, nameof(elementNames));

        return string.Join(", ", elementNames);
    }
}
