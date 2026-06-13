using Microsoft.Extensions.Localization;
using Moq;

namespace OrchardCoreContrib.Templating.Tests;

public class DefaultTemplateRendererTests
{
    [Fact]
    public async Task RenderAsync_ShouldReturnRenderedContent_WhenEngineExists()
    {
        // Arrange
        var templateEngineMock = new Mock<ITemplateEngine>();
        var templateContext = new TemplateContext();

        const string template = "Hello {{ name }}";
        const string expected = "Hello John";

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContext))
            .ReturnsAsync(expected);

        var templateRenderer = new DefaultTemplateRenderer(templateEngineMock.Object, Mock.Of<IStringLocalizer<DefaultTemplateRenderer>>());

        // Act
        var result = await templateRenderer.RenderAsync(template, templateContext);

        // Assert
        Assert.True(result.Succeeded);
    }

    //[Fact]
    //public async Task RenderAsync_ShouldThrowTemplateNotFoundException_WhenEngineDoesNotExist()
    //{
    //    // Arrange
    //    var templateEngineFactoryMock = new Mock<ITemplateEngineFactory>();
    //    var templateContext = new TemplateContext();

    //    const string template = "Hello";
    //    const string engineName = "missing-engine";

    //    templateEngineFactoryMock
    //        .Setup(x => x.GetEngine(engineName))
    //        .Returns((ITemplateEngine)null);

    //    var templateRenderer = new DefaultTemplateRenderer(templateEngineFactoryMock.Object, Mock.Of<IStringLocalizer<DefaultTemplateRenderer>>());

    //    // Act & Assert
    //    await Assert.ThrowsAsync<TemplateNotFoundException>(() => templateRenderer.RenderAsync(template, templateContext));
    //}

    [Fact]
    public async Task RenderAsync_ShouldWrapEngineException_InTemplateRenderException()
    {
        // Arrange
        var templateEngineMock = new Mock<ITemplateEngine>();
        var templateContext = new TemplateContext();

        const string template = "Hello";
        var inner = new InvalidOperationException("Engine failed");

        templateEngineMock
            .Setup(x => x.RenderAsync(template, templateContext))
            .ThrowsAsync(inner);

        var stringLocalizer = new Mock<IStringLocalizer<DefaultTemplateRenderer>>();

        stringLocalizer.Setup(l => l[It.IsAny<string>(), It.IsAny<object[]>()])
            .Returns<string, object[]>((n, a) => new LocalizedString(string.Format(n, a), string.Format(n, a)));

        var templateRenderer = new DefaultTemplateRenderer(templateEngineMock.Object, stringLocalizer.Object);

        // Act
        var result = await templateRenderer.RenderAsync(template, templateContext);

        // Assert
        Assert.False(result.Succeeded);
        Assert.Equal($"Error rendering with {templateEngineMock.Object.Name}.", result.Errors.Single().Message.Value);
    }
}
