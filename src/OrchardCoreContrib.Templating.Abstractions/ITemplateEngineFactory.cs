namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents a factory for creating template engines.
/// </summary>
public interface ITemplateEngineFactory
{
    /// <summary>
    /// Gets a template engine by name.
    /// </summary>
    /// <param name="name">The name of the template engine.</param>
    /// <returns>The template engine with the specified name.</returns>
    ITemplateEngine GetEngine(string name);

    /// <summary>
    /// Gets all registered template engines.
    /// </summary>
    /// <returns>A collection of all registered template engines.</returns>
    IEnumerable<ITemplateEngine> GetAllEngines();
}
