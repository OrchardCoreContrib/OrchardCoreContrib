namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents a template engine such as Liquid, Razor, HTML, etc.
/// </summary>
public interface ITemplateEngine
{
    /// <summary>
    /// Gets the name of the template engine.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Renders a template string with the given context.
    /// </summary>
    /// <param name="template">The template string to be rendered.</param>
    /// <param name="context">The context containing the data model and any additional information needed for rendering.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the rendered template string.</returns>
    Task<string> RenderAsync(string template, TemplateContext context);
}
