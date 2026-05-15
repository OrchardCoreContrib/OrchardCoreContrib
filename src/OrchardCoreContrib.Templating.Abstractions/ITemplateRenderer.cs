namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents a contract for rendering text templates.
/// </summary>
public interface ITemplateRenderer
{
    /// <summary>
    /// Renders a template string with the given context using the specified template engine.
    /// </summary>
    /// <param name="template">The template string to be rendered.</param>
    /// <param name="engineName">The name of the template engine to use.</param>
    /// <param name="context">The <see cref="ITemplateContext"/>.</param>
    /// <returns>A <see cref="TemplateResult"/> containing the rendered output and any errors.</returns>
    Task<TemplateResult> RenderAsync(string template, string engineName, ITemplateContext context);
}
