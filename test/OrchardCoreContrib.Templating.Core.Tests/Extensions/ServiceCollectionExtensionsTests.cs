using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCoreContrib.Templating.Tests;

namespace OrchardCoreContrib.Templating.Extensions.Tests;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddTemplating_RegistersCoreServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTemplating();

        // Assert
        using var provider = services.BuildServiceProvider();

        var manager = provider.GetService<TemplateEngineManager>();
        var factory = provider.GetService<ITemplateEngineFactory>();
        var renderer = provider.GetService<ITemplateRenderer>();

        Assert.NotNull(manager);
        Assert.NotNull(factory);
        Assert.NotNull(renderer);
        Assert.Same(manager, factory);
        Assert.IsType<DefaultTemplateRenderer>(renderer);
    }

    [Fact]
    public void AddTemplateEngine_RegistersTemplateEngineImplementation()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddOptions();
        services.AddTemplating();

        // Act
        services.AddTemplateEngine<TestTemplateEngine>();

        // Assert
        using var provider = services.BuildServiceProvider();

        var engines = provider.GetServices<ITemplateEngine>().ToList();

        Assert.Contains(engines, e => e.GetType() == typeof(TestTemplateEngine));
    }

    [Fact]
    public void AddTemplateEngine_RegistersPostConfigureForTemplateEngineManager()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddOptions();
        services.AddTemplating();

        // Act
        services.AddTemplateEngine<TestTemplateEngine>();

        // Assert
        using var provider = services.BuildServiceProvider();

        var postConfigurers = provider.GetServices<IPostConfigureOptions<TemplateEngineManager>>();

        Assert.NotEmpty(postConfigurers);
    }
}
