using OrchardCoreContrib.Infrastructure;
using RazorLight;

namespace OrchardCoreContrib.Templating.Razor;

/// <summary>
/// Represents a Razor-based template engine.
/// </summary>
public class RazorTemplateEngine : ITemplateEngine
{
    private readonly RazorLightEngine _engine;

    /// <summary>
    /// Creates a new instance of the <see cref="RazorTemplateEngine"/> class.
    /// </summary>
    public RazorTemplateEngine()
    {
        _engine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .Build();
    }

    /// <inheritdoc/>
    public string Name => "Razor";

    /// <inheritdoc/>
    public async Task<string> RenderAsync(string template, TemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template, nameof(template));
        Guard.ArgumentNotNull(context, nameof(context));

        try
        {
            return await _engine.CompileRenderStringAsync(Guid.NewGuid().ToString(), template, context.Model);
        }
        catch (Exception ex)
        {
            throw new TemplateRenderException("Razor rendering failed.", ex);
        }
    }
}
