namespace OrchardCoreContrib.Templating.Tests;

public sealed class TestTemplateEngine(string name) : ITemplateEngine
{
    public TestTemplateEngine() : this("Test")
    {
    }

    public string Name { get; } = name;

    public Task<string> RenderAsync(string template, TemplateContext context) => Task.FromResult(string.Empty);
}
