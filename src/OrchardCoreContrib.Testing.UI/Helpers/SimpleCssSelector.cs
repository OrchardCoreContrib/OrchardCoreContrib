using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Testing.UI.Helpers;

/// <summary>
/// Represents a utility class for creating CSS selectors.
/// </summary>
public static partial class By
{
    /// <summary>
    /// Generates a CSS selector to select all the elements.
    /// These is an example:
    /// <code>
    /// * {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    public static string All() => "*";

    /// <summary>
    /// Generates a CSS selector for an element with the specified id.
    /// These is an example:
    /// <code>
    /// #red {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="id">The element identifier.</param>
    public static string Id(string id)
    {
        Guard.ArgumentNotNullOrEmpty(id, nameof(id));

        return $"#{id}";
    }

    /// <summary>
    /// Generates a CSS selector for specified class and tag names.
    /// These are some examples:
    /// <code>
    /// .red {
    ///     color: red;
    /// }
    /// p.red {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="name">The CSS class name.</param>
    /// <param name="tagName">The optional tag name.</param>
    public static string ClassName(string name, string tagName = null)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        var selector = $".{name}";

        if (tagName is not null)
        {
            selector = tagName + selector;
        }

        return selector;
    }

    /// <summary>
    /// Generates a CSS selector for element by tag name.
    /// These is a example:
    /// <code>
    /// p {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="names">The tag name.</param>
    public static string TagName(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        return name;
    }

    /// <summary>
    /// Generates a CSS selector for elements by tag names aka grouping selector.
    /// These is an example:
    /// <code>
    /// h1, h2, h3 {
    ///     color: red;
    /// }
    /// </code>
    /// </summary>
    /// <param name="names">The tag names.</param>
    public static string TagNames(params string[] names)
    {
        Guard.ArgumentNotNullOrEmpty(names, nameof(names));

        return names.Length == 1
            ? TagName(names[0])
            : string.Join(", ", names);
    }
}
