using Fluid;
using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating.Liquid;

/// <summary>
/// Represents a template engine that uses the Liquid templating language.
/// </summary>
public class LiquidTemplateEngine : ITemplateEngine
{
    private readonly FluidParser _fluidParser = new();

    /// <inheritdoc/>
    public string Name => "Liquid";

    /// <inheritdoc/>
    public async Task<string> RenderAsync(string template, TemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template);
        Guard.ArgumentNotNull(context);

        if (!_fluidParser.TryParse(template, out var parsedTemplate, out var errors))
        {
            throw new TemplateRenderException($"Liquid parsing failed: {string.Join(", ", errors)}");
        }

        var fluidTemplateContext = new Fluid.TemplateContext(context.Model);

        try
        {
            return await parsedTemplate.RenderAsync(fluidTemplateContext);
        }
        catch (Exception ex)
        {
            throw new TemplateRenderException("Rendering liquid template failed.", ex);
        }
    }
}
