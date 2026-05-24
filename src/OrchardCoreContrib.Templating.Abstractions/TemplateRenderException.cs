using System.Reflection;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents an exception that is thrown when an error occurs during template rendering.
/// </summary>
public class TemplateRenderException : Exception
{
    /// <summary>
    /// Creates a new instance of the <see cref="TemplateRenderException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    public TemplateRenderException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="TemplateRenderException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="inner">The inner exception.</param>
    public TemplateRenderException(string message, Exception inner) : base(message, inner)
    {
    }
}
