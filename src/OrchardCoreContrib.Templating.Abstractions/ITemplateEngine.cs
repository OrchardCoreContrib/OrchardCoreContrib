namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents a template engine such asLiquid, Razor, HTML, etc.
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
    Task<string> RenderAsync(string template, ITemplateContext context);
}
