using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents a template engine such as Liquid, Razor, HTML, etc.
/// </summary>
public interface ITemplateEngine
{
    /// <summary>
    /// Renders a raw template string with the given context.
    /// </summary>
    /// <param name="template">The template string to be rendered.</param>
    /// <param name="context">The context containing the data model and any additional information needed for rendering.</param>
    /// <returns>A task result contains the rendered template string and any errors that occurred during rendering.</returns>
    Task<Result<string>> RenderAsync(string template, TemplateContext context);
}
