using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector for an element with the specified attribute and optional value and element name.
    /// These are some examples:
    /// <code>
    /// [target] {
    ///     color: red;
    /// }
    /// [target="_blank"]] {
    ///     color: red;
    /// }
    /// 
    /// a[target] {
    ///     color: red;
    /// }
    /// 
    /// a[target="_blank"] {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The optional attribute value.</param>
    /// <param name="elementName">The optional element name.</param>
    public static string Attribute(string name, string value = null, string elementName = null)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        var selector = value is null
            ? $"[{name}]"
            : $"[{name}=\"{value}\"]";

        if (elementName is not null)
        {
            selector = elementName + selector;
        }

        return selector;
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value containing a specified word or value.
    /// These are some examples:
    /// <code>
    /// [class~="re"] {
    ///     color: red;
    /// }
    /// p[class~="re"]] {
    ///     color: red;
    /// }
    /// 
    /// [class*="re"] {
    ///     color: red;
    /// }
    /// 
    /// p[class*="re"] {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <param name="elementName">The optional element name.</param>
    /// <param name="isWord">Check whether an attribute value containing a specified word or not.</param>
    public static string AttributeContains(string name, string value, string elementName = null, bool isWord = false)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        var selector = isWord
            ? $"[{name}~=\"{value}\"]"
            : $"[{name}*=\"{value}\"]";

        if (elementName is not null)
        {
            selector = elementName + selector;
        }

        return selector;
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value starts with a specified value.
    /// These are some examples:
    /// <code>
    /// [class^="re"] {
    ///     color: red;
    /// }
    /// p[class^"re"]] {
    ///     color: red;
    /// }
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <param name="elementName">The optional element name.</param> 
    public static string AttributeStartsWith(string name, string value, string elementName = null)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return elementName is null
            ? $"[{name}^=\"{value}\"]"
            : $"{elementName}[{name}^=\"{value}\"]";
    }

    /// <summary>
    /// Generates a CSS selector for an elements with an attribute value ends with a specified value.
    /// These are some examples:
    /// <code>
    /// [class$="ed"] {
    ///     color: red;
    /// }
    /// p[class$="ed"]] {
    ///     color: red;
    /// }
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <param name="elementName">The optional element name.</param>
    public static string AttributeEndsWith(string name, string value, string elementName = null)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        Guard.ArgumentNotNullOrEmpty(value, nameof(value));

        return elementName is null
            ? $"[{name}$=\"{value}\"]"
            : $"{elementName}[{name}$=\"{value}\"]";
    }
}
