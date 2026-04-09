using Microsoft.Extensions.DependencyInjection;
using Moq;
using OrchardCore.Environment.Shell;
using Xunit;

namespace OrchardCoreContrib.Settings.Extensions.Tests;

public class OrchardCoreBuilderExtensionsTests
{
    [Fact]
    public void AddGlobalSettingsAccessor_ShouldAddService()
    {
        // Arrange
        var services = new ServiceCollection()
            .AddSingleton(Mock.Of<IShellHost>());

        var builder = new OrchardCoreBuilder(services);

        // Act
        builder.AddGlobalSettingsAccessor();

        builder.ConfigureServices(services => services.BuildServiceProvider());

        var serviceProvider = services.BuildServiceProvider();

        // Assert
        var globalSettingsAccessor = serviceProvider.GetService<IGlobalSettingsAccessor>();

        Assert.NotNull(globalSettingsAccessor);
        Assert.IsType<GlobalSettingsAccessor>(globalSettingsAccessor);
    }
}
