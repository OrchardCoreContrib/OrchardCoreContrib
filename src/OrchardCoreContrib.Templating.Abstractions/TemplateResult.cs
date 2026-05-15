namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents the result of a template rendering operation, including the rendered output and any errors that occurred during rendering.
/// </summary>
public class TemplateResult
{
    /// <summary>
    /// Gets a value indicating whether the template rendering operation was successful.
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Gets the rendered output of the template.
    /// </summary>
    public string Output { get; init; }

    /// <summary>
    /// Gets the exception that occurred during template rendering, if any.
    /// </summary>
    public Exception Error { get; init; }

    /// <summary>
    /// Creates a successful <see cref="TemplateResult"/> with the specified output.
    /// </summary>
    /// <param name="output">The rendered output of the template.</param>
    /// <returns>A <see cref="TemplateResult"/> representing a successful rendering operation.</returns>
    public static TemplateResult Ok(string output) => new() { Success = true, Output = output };

    /// <summary>
    /// Creates a failed <see cref="TemplateResult"/> with the specified exception.
    /// </summary>
    /// <param name="exception">The exception that occurred during template rendering.</param>
    /// <returns>A <see cref="TemplateResult"/> representing a failed rendering operation.</returns>
    public static TemplateResult Fail(Exception exception) => new() { Success = false, Error = exception };
}
