using Microsoft.Extensions.Localization;
using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents the default implementation of the <see cref="ITemplateRenderer"/> interface, which uses an <see cref="ITemplateEngine"/> to render templates.
/// </summary>
/// <param name="templateEngine">The <see cref="ITemplateEngine"/>.</param>
public class DefaultTemplateRenderer(ITemplateEngine templateEngine, IStringLocalizer<DefaultTemplateRenderer> S) : ITemplateRenderer
{
    /// <inheritdoc/>
    public async Task<Result> RenderAsync(string template, TemplateContext context)
    {
        Guard.ArgumentNotNullOrEmpty(template);

        Guard.ArgumentNotNull(context);

        try
        {
            var result = await templateEngine.RenderAsync(template, context);

            return Result.Success(result);
        }
        catch
        {
            return Result.Failed(S["Error rendering with {0}.", templateEngine.Name]);
        }
    }
}
