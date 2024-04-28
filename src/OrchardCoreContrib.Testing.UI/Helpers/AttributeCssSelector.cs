using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for an element with the specified attribute.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    public static string Attribute(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return $"[{name}]";
    }

    /// <summary>
    /// Generates a CSS selector for an element with the specified attribute and value.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    public static string Attribute(string name, string value)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return $"[{name}='{value}']";
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value containing a specified word or value.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <param name="value">Check whether an attribute value containing a specified word or not.</param>
    public static string AttributeContains(string name, string value, bool isWord = false)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return isWord
            ? $"[{name}~=\"{value}\"]"
            : $"[{name}*=\"{value}\"]";
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value starts with a specified value.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    public static string AttributeStartsWith(string name, string value)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return $"[{name}^=\"{value}\"]";
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value ends with a specified value.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    public static string AttributeEndsWith(string name, string value)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return $"[{name}$=\"{value}\"]";
    }
}
