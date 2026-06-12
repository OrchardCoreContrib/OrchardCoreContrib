using Microsoft.Extensions.Localization;
using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents the default implementation of the <see cref="ITemplateRenderer"/> interface, which uses an <see cref="ITemplateEngineFactory"/> to retrieve the appropriate template engine for rendering templates.
/// </summary>
/// <param name="factory">The <see cref="ITemplateEngineFactory"/>.</param>
public class DefaultTemplateRenderer(ITemplateEngineFactory factory, IStringLocalizer<DefaultTemplateRenderer> S) : ITemplateRenderer
{
    /// <inheritdoc/>
    public async Task<Result> RenderAsync(string template, string engineName, TemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template);
        Guard.ArgumentNotNullOrEmpty(engineName);
        Guard.ArgumentNotNull(context);

        var engine = factory.GetEngine(engineName) ?? throw new TemplateNotFoundException(engineName);

        try
        {
            var output = await engine.RenderAsync(template, context);

            return Result.Success(output);
        }
        catch
        {
            return Result.Failed(S["Error rendering with {0}.", engineName]);
        }
    }
}
