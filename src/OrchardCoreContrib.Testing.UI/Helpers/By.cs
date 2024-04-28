using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static class By
{
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
    /// Generates a CSS selector for an element with the specified name.
    /// </summary>
    /// <param name="name">The element name.</param>
    public static string Name(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return name;
    }

    /// <summary>
    /// Generates a CSS selector for an element with the specified attribute.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    public static string Attribute(string name, string value = null)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        
        return value == null
            ? $"[{name}]"
            : $"[{name}='{value}']";
    }
}
