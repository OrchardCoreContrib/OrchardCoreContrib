using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Manages the registration and retrieval of template engines.
/// </summary>
public class TemplateEngineManager : ITemplateEngineFactory
{
    private readonly Dictionary<string, ITemplateEngine> _engines = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Registers a template engine with the manager.
    /// </summary>
    /// <param name="engine">The <see cref="ITemplateEngine"/> to register.</param>
    public void RegisterEngine(ITemplateEngine engine)
    {
        Guard.ArgumentNotNull(engine, nameof(engine));

        _engines[engine.Name] = engine;
    }

    /// <inheritdoc/>
    public ITemplateEngine GetEngine(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));

        _engines.TryGetValue(name, out var engine);

        return engine;
    }

    /// <inheritdoc/>
    public IEnumerable<ITemplateEngine> GetAllEngines() => _engines.Values;
}
