using OrchardCoreContrib.Infrastructure;
using RazorLight;

namespace OrchardCoreContrib.Templating.Razor;

public class RazorTemplateEngine : ITemplateEngine
{
    private readonly RazorLightEngine _engine;

    public RazorTemplateEngine()
    {
        _engine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .Build();
    }

    public string Name => "Razor";

    public Task<string> RenderAsync(string template, TemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template, nameof(template));
        Guard.ArgumentNotNull(context, nameof(context));

        try
        {
            return _engine.CompileRenderStringAsync(Guid.NewGuid().ToString(), template, context.Model);
        }
        catch (Exception ex)
        {
            throw new TemplateRenderException("Razor rendering failed.", ex);
        }
    }
}
