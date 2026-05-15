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
        var templateContextMock = new Mock<ITemplateContext>();

        const string template = "Hello {{ name }}";
        const string engineName = "liquid";
        const string expected = "Hello John";

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns(templateEngineMock.Object);

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContextMock.Object))
            .ReturnsAsync(expected);

        var sut = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act
        var result = await sut.RenderAsync(template, engineName, templateContextMock.Object);

        // Assert
        Assert.Equal(expected, result.Output);
    }

    [Fact]
    public async Task RenderAsync_ShouldThrowTemplateNotFoundException_WhenEngineDoesNotExist()
    {
        // Arrange
        var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
        var templateContextMock = new Mock<ITemplateContext>();

        const string template = "Hello";
        const string engineName = "missing-engine";

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns((ITemplateEngine)null);

        var sut = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act & Assert
        await Assert.ThrowsAsync<TemplateNotFoundException>(() => sut.RenderAsync(template, engineName, templateContextMock.Object));
    }

    [Fact]
    public async Task RenderAsync_ShouldWrapEngineException_InTemplateRenderException()
    {
        // Arrange
        var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
        var templateEngineMock = new Mock<ITemplateEngine>();
        var templateContextMock = new Mock<ITemplateContext>();

        const string template = "Hello";
        const string engineName = "liquid";
        var inner = new InvalidOperationException("Engine failed");

        templateEngineFactoryMock
            .Setup(x => x.GetEngine(engineName))
            .Returns(templateEngineMock.Object);

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContextMock.Object))
            .ThrowsAsync(inner);

        var templateRenderer = new DefaultTemplateRenderer(templateEngineFactoryMock.Object);

        // Act
        var result = await templateRenderer.RenderAsync(template, engineName, templateContextMock.Object);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.Error is TemplateRenderException);
        Assert.Equal($"Error rendering with {engineName}", result.Error.Message);
        Assert.Same(inner, result.Error.InnerException);
    }
}
