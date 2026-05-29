namespace OrchardCoreContrib.Templating.Liquid.Tests;

public class LiquidTemplateEngineTests
{
    private readonly LiquidTemplateEngine _templateEngine = new();

    [Fact]
    public void Name_ShouldBeLiquid()
    {
        // Act & Assert
        Assert.Equal("Liquid", _templateEngine.Name);
    }

    [Fact]
    public async Task RenderAsync_ShouldRenderTemplate_WhenTemplateIsValid()
    {
        // Arrange
        var template = "Hello {{ name }}";
        var context = new TemplateContext(new { name = "World" });

        // Act
        var result = await _templateEngine.RenderAsync(template, context);

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public async Task RenderAsync_ShouldThrowTemplateRenderException_WhenTemplateParsingFails()
    {
        // Arrange
        var template = "{{";
        var context = new TemplateContext();

        // Act
        var exception = await Assert.ThrowsAsync<TemplateRenderException>(() => _templateEngine.RenderAsync(template, context));

        // Assert
        Assert.StartsWith("Liquid parsing failed:", exception.Message);
    }
}
