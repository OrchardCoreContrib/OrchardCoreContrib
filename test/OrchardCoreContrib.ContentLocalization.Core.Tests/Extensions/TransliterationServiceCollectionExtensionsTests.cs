using Microsoft.Extensions.DependencyInjection;
using OrchardCoreContrib.ContentLocalization.Transliteration;

namespace OrchardCoreContrib.ContentLocalization.Extensions.Tests;

public class TransliterationServiceCollectionExtensionsTests
{
    [Fact]
    public void AddTransliteration_ReturnsSameServiceCollection()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection();

        // Act
        var result = services.AddTransliteration();

        // Assert
        Assert.Same(services, result);
    }

    [Fact]
    public void AddTransliteration_RegistersRuleProviderAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddTransliteration();

        // Assert
        var descriptor = Assert.Single(services, d => d.ServiceType == typeof(ITransliterateRuleProvider));

        Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
        Assert.Equal(typeof(DefaultTransliterateRuleProvider), descriptor.ImplementationType);

        using var provider = services.BuildServiceProvider();
        var first = provider.GetRequiredService<ITransliterateRuleProvider>();
        var second = provider.GetRequiredService<ITransliterateRuleProvider>();

        Assert.Same(first, second);
    }
}
