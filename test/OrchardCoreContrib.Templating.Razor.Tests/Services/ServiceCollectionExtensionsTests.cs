using Microsoft.Extensions.DependencyInjection;

namespace OrchardCoreContrib.Templating.Razor.Services.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddRazorTemplating_ReturnsSameServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        var result = services.AddRazorTemplating();

        // Assert
        Assert.Same(services, result);
    }

    [Fact]
    public void AddRazorTemplating_RegistersRazorTemplateEngineAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddRazorTemplating();

        // Assert
        using var provider = services.BuildServiceProvider();

        var first = provider.GetRequiredService<ITemplateEngine>();
        var second = provider.GetRequiredService<ITemplateEngine>();

        Assert.IsType<RazorTemplateEngine>(first);
        Assert.Same(first, second);
    }
}
