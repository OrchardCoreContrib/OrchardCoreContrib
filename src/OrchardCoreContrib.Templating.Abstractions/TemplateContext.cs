namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents the context for template rendering, containing the model and any additional data needed during the rendering process.
/// </summary>
public class TemplateContext
{
    /// <summary>
    /// Creates a new instance of <see cref="TemplateContext"/>.
    /// </summary>
    public TemplateContext()
    {
    }

    /// <summary>
    /// Creates a new instance of <see cref="TemplateContext"/> with the specified model.
    /// </summary>
    /// <param name="model">The data model to be associated with this context.</param>
    public TemplateContext(object model)
    {
        Model = model;
    }

    /// <summary>
    /// Gets the data model associated with this instance.
    /// </summary>
    /// <remarks>The model can be of any type, depending on the context in which this property is used.
    /// Consumers are responsible for casting the value to the expected type before use.</remarks>
    public object Model { get; }
}
