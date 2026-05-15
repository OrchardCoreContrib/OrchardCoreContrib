namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents an exception that is thrown when an error occurs during template rendering.
/// </summary>
/// <param name="message">The error message.</param>
/// <param name="inner">The inner exception.</param>
public class TemplateRenderException(string message, Exception inner) : Exception(message, inner);
