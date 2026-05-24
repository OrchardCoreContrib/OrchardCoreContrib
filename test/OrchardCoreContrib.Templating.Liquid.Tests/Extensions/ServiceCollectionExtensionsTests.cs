using Microsoft.Extensions.DependencyInjection;

namespace OrchardCoreContrib.Templating.Liquid.Tests.Extensions;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddLiquidTemplating_ReturnsSameServiceCollection()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        var result = services.AddLiquidTemplating();

        // Assert
        Assert.Same(services, result);
    }

    [Fact]
    public void AddLiquidTemplating_RegistersLiquidTemplateEngineAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddLiquidTemplating();

        // Assert
        using var provider = services.BuildServiceProvider();

        var first = provider.GetRequiredService<ITemplateEngine>();
        var second = provider.GetRequiredService<ITemplateEngine>();

        Assert.IsType<LiquidTemplateEngine>(first);
        Assert.Same(first, second);
    }
}
