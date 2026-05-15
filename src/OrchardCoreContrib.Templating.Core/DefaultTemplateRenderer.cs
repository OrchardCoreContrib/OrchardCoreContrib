using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents the default implementation of the <see cref="ITemplateRenderer"/> interface, which uses an <see cref="ITemplateEngineFactory"/> to retrieve the appropriate template engine for rendering templates.
/// </summary>
/// <param name="factory">The <see cref="ITemplateEngineFactory"/>.</param>
public class DefaultTemplateRenderer(ITemplateEngineFactory factory) : ITemplateRenderer
{
    /// <inheritdoc/>
    public async Task<TemplateResult> RenderAsync(string template, string engineName, ITemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template, nameof(template));
        Guard.ArgumentNotNullOrEmpty(engineName, nameof(engineName));
        Guard.ArgumentNotNull(context, nameof(context));

        var engine = factory.GetEngine(engineName) ?? throw new TemplateNotFoundException(engineName);

        try
        {
            var output = await engine.RenderAsync(template, context);

            return TemplateResult.Ok(output);
        }
        catch (Exception ex)
        {
            return TemplateResult.Fail(new TemplateRenderException($"Error rendering with {engineName}", ex));
        }
    }
}
