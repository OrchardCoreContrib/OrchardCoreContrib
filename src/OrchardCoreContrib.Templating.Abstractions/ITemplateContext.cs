namespace OrchardCoreContrib.Templating;

/// <summary>
/// Provides contextual data for template rendering.
/// </summary>
public interface ITemplateContext
{
    /// <summary>
    /// Arbitrary data model passed into the template.
    /// </summary>
    IDictionary<string, object> Data { get; }

    /// <summary>
    /// Services or helpers available during rendering.
    /// </summary>
    IServiceProvider Services { get; }
}
