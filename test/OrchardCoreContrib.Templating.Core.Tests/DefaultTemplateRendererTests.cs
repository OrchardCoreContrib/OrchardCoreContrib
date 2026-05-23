using Moq;

namespace OrchardCoreContrib.Templating.Tests;

public class DefaultTemplateRendererTests
{
    [Fact]
    public async Task RenderAsync_ShouldReturnRenderedContent_WhenEngineExists()
    {
        // Arrange
        var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
        var templateEngineMock = new Mock<ITemplateEngine>();
        var templateContext = new TemplateContext();

        const string template = "Hello {{ name }}";
        const string engineName = "liquid";
        const string expected = "Hello John";

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns(templateEngineMock.Object);

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContext))
            .ReturnsAsync(expected);

        var sut = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act
        var result = await sut.RenderAsync(template, engineName, templateContext);

        // Assert
        Assert.Equal(expected, result.Output);
    }

    [Fact]
    public async Task RenderAsync_ShouldThrowTemplateNotFoundException_WhenEngineDoesNotExist()
    {
        // Arrange
        var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
        var templateContext = new TemplateContext();

        const string template = "Hello";
        const string engineName = "missing-engine";

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns((ITemplateEngine)null);

        var sut = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<TemplateNotFoundException>(() => sut.RenderAsync(template, engineName, templateContext));
    }

    [Fact]
    public async Task RenderAsync_ShouldWrapEngineException_InTemplateRenderException()
    {
        // Arrange
        var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
        var templateEngineMock = new Mock<ITemplateEngine>();
        var templateContext = new TemplateContext();

        const string template = "Hello";
        const string engineName = "liquid";
        var inner = new InvalidOperationException("Engine failed");

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns(templateEngineMock.Object);

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContext))
            .ThrowsAsync(inner);

        var templateRenderer = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act
        var result = await templateRenderer.RenderAsync(template, engineName, templateContext);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.Error is TemplateRenderException);
        Assert.Equal($"Error rendering with {engineName}", result.Error.Message);
        Assert.Same(inner, result.Error.InnerException);
    }
}
