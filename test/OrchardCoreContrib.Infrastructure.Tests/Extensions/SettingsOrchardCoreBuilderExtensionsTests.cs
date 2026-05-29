using Microsoft.Extensions.DependencyInjection;
using Moq;
using OrchardCore.Environment.Shell;
using OrchardCoreContrib.Settings;
using Xunit;

namespace OrchardCoreContrib.Infrastructure.Extensions.Tests;

public class SettingsOrchardCoreBuilderExtensionsTests
{
    [Fact]
    public void AddGlobalSettingsAccessor_ReturnsSameBuilder()
    {
        // Arrange
        var services = new ServiceCollection();
        var builder = new OrchardCoreBuilder(services);

        // Act
        var result = builder.AddGlobalSettingsAccessor();

        // Assert
        Assert.Same(builder, result);
    }

    [Fact]
    public void AddGlobalSettingsAccessor_RegistersGlobalSettingsAccessorAsSingleton()
    {
        // Arrange
        var services = new ServiceCollection();
        services.AddSingleton(Mock.Of<IShellHost>());
        var builder = new OrchardCoreBuilder(services);

        // Act
        builder.AddGlobalSettingsAccessor();

        // Assert
        var descriptor = Assert.Single(
            builder.ApplicationServices,
            d => d.ServiceType == typeof(IGlobalSettingsAccessor));

        Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
        Assert.Equal(typeof(GlobalSettingsAccessor), descriptor.ImplementationType);

        using var provider = builder.ApplicationServices.BuildServiceProvider();
        var first = provider.GetRequiredService<IGlobalSettingsAccessor>();
        var second = provider.GetRequiredService<IGlobalSettingsAccessor>();

        Assert.Same(first, second);
    }
}
