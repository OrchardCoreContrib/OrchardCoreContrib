namespace OrchardCoreContrib.Templating.Razor.Tests;

public class RazorTemplateEngineTests
{
    private readonly RazorTemplateEngine _templateEngine = new();

    [Fact]
    public void Name_ShouldBeRazor()
    {
        // Act & Assert
        Assert.Equal("Razor", _templateEngine.Name);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public async Task RenderAsync_ShouldThrow_WhenTemplateIsNullOrEmpty(string template)
    {
        // Arrange
        var context = new TemplateContext(new { Name = "World" });

        // Act & Assert
        await Assert.ThrowsAnyAsync<ArgumentException>(() => _templateEngine.RenderAsync(template!, context));
    }

    [Fact]
    public async Task RenderAsync_ShouldThrow_WhenContextIsNull()
    {
        // Act & Assert
        await Assert.ThrowsAnyAsync<ArgumentNullException>(() => _templateEngine.RenderAsync("Hello @Model.Name", null!));
    }

    [Fact]
    public async Task RenderAsync_ShouldRenderTemplate_WithModel()
    {
        // Arrange
        var context = new TemplateContext(new { Name = "World" });

        // Act
        var result = await _templateEngine.RenderAsync("Hello @Model.Name", context);

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public async Task RenderAsync_ShouldThrow_WhenTemplateIsInvalid()
    {
        // Arrange
        var context = new TemplateContext(new { Name = "World" });

        // Act & Assert
        await Assert.ThrowsAnyAsync<Exception>(() => _templateEngine.RenderAsync("@{ var x = ; }", context));
    }
}
